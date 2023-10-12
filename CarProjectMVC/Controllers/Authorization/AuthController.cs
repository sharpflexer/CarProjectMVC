using CarProjectMVC.JWT;
using CarProjectMVC.Services.Interfaces;
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
            HttpContext.Response.Cookies.Append("Refresh", refreshToken, new CookieOptions()
            {
                HttpOnly = true
            });
            _requestService.AddRefreshToken(user);
            return Ok(accessToken);
        }

        /// <summary>
        /// Обновляет токен
        /// </summary>
        /// <param name="oldToken">Токен, который требуется заменить</param>
        /// <returns>Результат обновления</returns>
        [HttpGet]
        public IActionResult Refresh()
        {

            JwtToken oldToken = GetOldJwtToken(HttpContext.Request);

            if (oldToken.RefreshToken is null)
                return BadRequest("Invalid client request");

            JwtToken newToken = _tokenService.CreateNewToken(oldToken);
            HttpContext.Response.Cookies.Append("Refresh", newToken.RefreshToken, new CookieOptions()
            {
                HttpOnly = true
            });
            return Ok(newToken.AccessToken);
        }

        private static JwtToken GetOldJwtToken(HttpRequest request)
        {
            string oldAccessToken = request.Headers["Authorization"].ToString().Split(" ")[0];
            string oldRefreshToken = request.Cookies["Refresh"].Split(";")[0];

            return new JwtToken
            {
                AccessToken = oldAccessToken,
                RefreshToken = oldRefreshToken
            };
        }
    }
}
