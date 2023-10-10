using CarProjectMVC.JWT;
using CarProjectMVC.Services.Authenticate;
using CarProjectMVC.Services.Request;
using CarProjectMVC.Services.Token;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectMVC.Controllers.Authorization
{
    public class AuthController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IAuthenticateService _authenticateService;
        private readonly IRequestService _requestService;

        public AuthController(ITokenService tokenService, IAuthenticateService authenticateService, IRequestService requestService)
        {
            _tokenService = tokenService;
            _authenticateService = authenticateService;
            _requestService = requestService;
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
        public async Task<IActionResult> Token(string username, string password)
        {
            var user = await _authenticateService.AuthenticateUser(username, password);
            var accessToken = _tokenService.CreateToken(user);
            var refreshToken = _tokenService.CreateRefreshToken();

            user.RefreshToken = refreshToken;
            _requestService.AddRefreshToken(user);
            return Ok(new JwtToken
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }

        /// <summary>
        /// Обновляет токен
        /// </summary>
        /// <param name="oldToken">Токен, который требуется заменить</param>
        /// <returns>Результат обновления</returns>
        [HttpGet]
        public IActionResult Refresh()
        {

            JwtToken oldToken = GetOldJwtToken(HttpContext.Request.Cookies);

            if (oldToken.RefreshToken is null)
                return BadRequest("Invalid client request");

            JwtToken newToken = _tokenService.CreateNewToken(oldToken);

            HttpContext.Response.Cookies.Delete("Authorization");
            HttpContext.Response.Cookies.Delete("Refresh");
            HttpContext.Response.Cookies.Append("Authorization", newToken.AccessToken);
            HttpContext.Response.Cookies.Append("Refresh", newToken.RefreshToken);

            return RedirectToAction("Index", "Login");
        }

        private static JwtToken GetOldJwtToken(IRequestCookieCollection cookies)
        {
            string oldAccessToken = cookies["Authorization"].Split(";")[0];
            string oldRefreshToken = cookies["Refresh"].Split(";")[0]; ;

            return new JwtToken
            {
                AccessToken = oldAccessToken,
                RefreshToken = oldRefreshToken
            };
        }
    }
}
