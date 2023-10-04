using CarProjectMVC.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarProjectMVC.Controllers.CRUD
{
    [Authorize(Policy = "Read")]
    public class ReadJSController : Controller
    {
        private readonly ApplicationContext _context;

        public ReadJSController(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает все марки автомобилей из БД
        /// </summary>
        /// <returns>Список марок автомобилей</returns>
        public JsonResult GetBrands()
        {
            return new(_context.Brands.Include(b => b.Models).AsNoTracking());
        }

        /// <summary>
        /// Получает модели определенной марки автомобилей по ID из БД
        /// </summary>
        /// <param name="id">ID автомобильной марки</param>
        /// <returns>Список моделей автомобилей</returns>
        public JsonResult GetModels(int id)
        {
            return new(_context.Brands.Include(b => b.Models)
                                      .AsNoTracking()
                                      .Single(b => b.Id.Equals(id))
                                      .Models);
        }

        /// <summary>
        /// Получает расцветки автомобилей, доступных для определенной модели по ID из БД
        /// </summary>
        /// <param name="id">ID модели автомобиля</param>
        /// <returns></returns>
        public JsonResult GetColors(int id)
        {
            return new(_context.Models.Include(m => m.Colors)
                                      .AsNoTracking()
                                      .Single(m => m.Id.Equals(id))
                                      .Colors);
        }
    }
}
