using CarProjectMVC.Context;
using CarProjectMVC.Models;
using CarProjectMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CarProjectMVC.Controllers
{
    public class ReadController : Controller
    {
        private readonly ApplicationContext _context;

        /// <summary>
        /// Сервис для отправки запросов в БД
        /// </summary>
        private readonly IRequestService _requestService;

        public ReadController(ApplicationContext context, IRequestService requestService)
        {
            _context = context;
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