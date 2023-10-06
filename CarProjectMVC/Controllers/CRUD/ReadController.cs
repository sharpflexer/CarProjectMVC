using CarProjectMVC.Models;
using CarProjectMVC.Services.Request;
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
    }
}