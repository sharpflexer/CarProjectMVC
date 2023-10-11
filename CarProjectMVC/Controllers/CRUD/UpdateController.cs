using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectMVC.Controllers.CRUD
{
    [Authorize(Policy = "Update")]
    public class UpdateController : Controller
    {

        /// <summary>
        /// Сервис для отправки запросов в БД
        /// </summary>
        private readonly IRequestService _requestService;

        public UpdateController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        /// <summary>
        /// Отправляет запрос на добавление автомобиля в базу данных через IRequestService.CreateAsync().
        /// Требует заполненных списков HttpContext.Request.Form
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> PostAsync()
        {
            await _requestService.UpdateAsync(HttpContext.Request.Form);
            return RedirectToAction("Index", "Read");
        }
    }
}
