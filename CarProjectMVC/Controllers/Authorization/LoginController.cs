using CarProjectMVC.Areas.Identity.Data;
using CarProjectMVC.JWT;
using CarProjectMVC.Services.Authenticate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CarProjectMVC.Controllers.Authorization
{
    public class LoginController : Controller
    {
        /// <summary>
        /// Сервис для отправки запросов в БД
        /// </summary>
        private readonly IAuthenticateService _authenticateService;
        public LoginController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        /// <summary>
        /// Загружает страницу входа, если юзер не авторизован 
        /// или страницу с таблицей, если авторизован
        /// </summary>
        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Read");
            return View();
        }

        /// <summary>
        /// Проверяет данные пользователя для входа
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns>
        /// Результат валидации пользователя
        /// </returns>
        [HttpPost]
        public async Task<object> PostAsync(string username, string password)
        {
            var isSuccess = _authenticateService.AuthenticateUser(username, password);



            return await SignInIfSucceed(username, isSuccess);
        }

        /// <summary>
        /// Производит выход пользователя из аккаунта
        /// </summary>
        /// <returns>Перенаправление на страницу входа</returns>
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Выполняет авторизацию и перенаправляет на страницу с таблицей, 
        /// если пользователь прошел аутентификацию
        /// или возвращает сообщение, если не прошел
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="isSuccess">Результат проверки</param>
        /// <returns>
        /// <list type="bullet|number|table">
        /// <listheader>
        /// <description>Новое представление, в зависимости от результата входа</description>
        /// </listheader>
        /// <item><term>Успешный вход</term><description> /Read/Index</description></item>
        /// <item><term>Неудачный вход</term><description> BadRequest</description></item>
        /// </list>
        /// </returns>
        private async Task<object> SignInIfSucceed(string username, Task<User> isSuccess)
        {
            if (isSuccess.Result != null)
            {
                object jwt = GetToken(isSuccess.Result);

                ViewBag.username = string.Format("Successfully logged-in", username);
                TempData["username"] = username;
                return RedirectToAction("Index", "Read", jwt);
                // return jwt;
            }
            else
            {
                ViewBag.username = string.Format("Login Failed: {0}", username);
                return BadRequest("Логин и/или пароль не установлены");
            }
        }

        public object GetToken(User user)
        {
            List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Login),
                    new Claim("CanCreate", user.Role.CanCreate.ToString()),
                    new Claim("CanRead", user.Role.CanRead.ToString()),
                    new Claim("CanUpdate", user.Role.CanUpdate.ToString()),
                    new Claim("CanDelete", user.Role.CanDelete.ToString())
                };

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(5)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
