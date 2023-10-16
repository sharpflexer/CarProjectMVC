using CarProjectMVC.Areas.Identity.Data;
using CarProjectMVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectMVC.Controllers.Authorization
{
    /// <summary>
    /// Контроллер для выхода из аккаунта
    /// </summary>
    public class LogOutController : Controller
    {
        /// <summary>
        /// Сервис для аутентификации пользователей
        /// </summary>
        private readonly IAuthenticateService _authenticateService;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LogOutController> _logger;

        /// <summary>
        /// Инициализирует контроллер сервисом аутентификации
        /// </summary>
        /// <param name="authenticateService">Сервис для аутентификации пользователей</param>
        public LogOutController(IAuthenticateService authenticateService, SignInManager<User> signInManager, ILogger<LogOutController> logger)
        {
            _authenticateService = authenticateService;
            _signInManager = signInManager;
            _logger = logger;
        }

        /// <summary>
        /// Производит выход пользователя из аккаунта
        /// </summary>
        /// <returns>Перенаправление на страницу входа</returns>
        [Authorize]
        public IActionResult Index()
        {
            HttpContext.Response.Cookies.Delete("Refresh");
            HttpContext.Response.Headers.Remove("Authentication");
            string? refreshCookie = HttpContext.Request.Cookies["Refresh"];
            _authenticateService.Revoke(refreshCookie);
            return RedirectToAction("Index", "Login");
        }
    }
}
