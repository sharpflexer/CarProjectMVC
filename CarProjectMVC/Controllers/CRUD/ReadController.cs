using CarProjectMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarProjectMVC.Controllers.CRUD
{
    [Authorize(Policy = "Read")]
    public class ReadController : Controller
    {
        /// <summary>
        /// Сервис для отправки запросов в БД
        /// </summary>
        private readonly IRequestService _requestService;

        public ReadController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// Загружает список автомобилей на страницу
        /// </summary>
        /// <returns>Страница с данными автомобилей в таблице</returns>
        public IActionResult IndexAsync()
        {
            ViewData["cars"] = _requestService.Read();
            return View();
        }

        /// <summary>
        /// Показывает ошибку
        /// </summary>
        /// <returns>Страница с ошибкой</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Устанавливает Access Token статус expired истекшим
        /// </summary>
        /// <returns>Страницу Read</returns>
        public async Task<IActionResult> Expire()
        {
            var auth = HttpContext.Request.Cookies["Authorization"];
            var authParts = auth?.Split(';');
            var newAuth = authParts[0] + "; expires=" + TimeSpan.FromSeconds(1).ToString() + ";" + authParts[2];
            var jwtToken = authParts[0];

            HttpContext.Response.Cookies.Delete("Authorization");
            HttpContext.Response.Cookies.Append(
            "Authorization",
            jwtToken,
            new CookieOptions()
            {
                Expires = DateTime.UtcNow,
                Path = "/"
            }
        );

            return RedirectToAction("Index");
        }
    }
}