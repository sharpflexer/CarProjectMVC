﻿using CarProjectMVC.Services.Authenticate;
using CarProjectMVC.Services.Token;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarProjectMVC.Controllers.Authorization
{
    public class LoginController : Controller
    {
        /// <summary>
        /// Сервис для отправки запросов в БД
        /// </summary>
        private readonly IAuthenticateService _authenticateService;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public LoginController(IAuthenticateService authenticateService, ITokenService tokenService, IConfiguration configuration)
        {
            _authenticateService = authenticateService;
            _tokenService = tokenService;
            _configuration = configuration;
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
        public async Task<object> Token(string username, string password)
        {
            var isSuccess = await _authenticateService.AuthenticateUser(username, password);
            var accessToken = _tokenService.CreateToken(isSuccess);
            return accessToken;
        }


        [HttpGet]
        public async Task<IActionResult> RedirectToRead()
        {
            var keys = HttpContext.Session.Keys;
            var redirect = RedirectToAction("Index", "Read");
            return redirect;
        }

        /// <summary>
        /// Производит выход пользователя из аккаунта
        /// </summary>
        /// <returns>Перенаправление на страницу входа</returns>
        public async Task<IActionResult> LogOut()
        {
            HttpContext.Response.Cookies.Delete("Authorization");
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
        private async Task<object> SignInIfSucceed(string username, Areas.Identity.Data.User isSuccess)
        {
            if (isSuccess != null)
            {
                ViewBag.username = string.Format("Successfully logged-in", username);
                TempData["username"] = username;
                return RedirectToAction("Index", "Read");
            }
            else
            {
                ViewBag.username = string.Format("Login Failed: {0}", username);
                return BadRequest("Логин и/или пароль не установлены");
            }
        }
    }
}
