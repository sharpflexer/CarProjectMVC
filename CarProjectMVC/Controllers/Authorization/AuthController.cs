using CarProjectMVC.JWT;
using CarProjectMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectMVC.Controllers.Authorization
{
    /// <summary>
    /// Контроллер для получения и обновления токенов
    /// </summary>
    public class AuthController : Controller
    {
        /// <summary>
        /// Сервис для работы с JWT токенами
        /// </summary>
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Сервис для аутентификации пользователей
        /// </summary>
        private readonly IAuthenticateService _authenticateService;

        /// <summary>
        /// Сервис для отправки запросов в БД
        /// </summary>
        private readonly IRequestService _requestService;

        /// <summary>
        /// Инициализирует контроллер сервисами токенов, аутентификации и запросов в БД
        /// </summary>
        /// <param name="tokenService">Сервис для работы с JWT токенами</param>
        /// <param name="authenticateService">Сервис для аутентификации пользователей</param>
        /// <param name="requestService">Сервис для отправки запросов в БД</param>
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
            {
                return BadRequest("Invalid client request");
            }

            JwtToken newToken = _tokenService.CreateNewToken(oldToken);
            HttpContext.Response.Cookies.Append("Refresh", newToken.RefreshToken, new CookieOptions()
            {
                HttpOnly = true
            });

            return Ok(newToken.AccessToken);
        }

        /// <summary>
        /// Получает устаревший токен из запроса
        /// </summary>
        /// <param name="request">HTTP-запрос</param>
        /// <returns>Устаревший токен</returns>
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
