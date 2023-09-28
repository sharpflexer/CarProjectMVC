using CarProjectMVC.Context;
using CarProjectMVC.Models;
using CarProjectMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarProjectMVC.Controllers
{
    public class CreateController : Controller
    {
        private readonly ApplicationContext _context;

        private readonly IRequestService _requestService;

        public CreateController(ApplicationContext context, IRequestService requestService)
        {
            _context = context;
            _requestService = requestService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync()
        {
            await _requestService.CreateAsync(HttpContext.Request.Form);
            return RedirectToAction("Index", "Read");
        }

        public JsonResult GetBrands()
        {
            return new(_context.Brands.Include(b => b.Models).AsNoTracking());
        }

        public JsonResult GetModels(int id)
        {
            return new(_context.Brands.Include(b => b.Models)
                                      .AsNoTracking()
                                      .Single(b => b.Id.Equals(id))
                                      .Models);
        }

        public JsonResult GetColors(int id)
        {
            return new(_context.Models.Include(m => m.Colors)
                                      .AsNoTracking()
                                      .Single(m => m.Id.Equals(id))
                                      .Colors);
        }
    }
}
