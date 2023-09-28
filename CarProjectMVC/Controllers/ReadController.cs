using CarProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CarProjectMVC.Controllers
{
    public class ReadController : Controller
    {
        ApplicationContext _context;
        private readonly ILogger<ReadController> _logger;

        public ReadController(ApplicationContext context, ILogger<ReadController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["MyData"] = _context.Cars.Include(car => car.Brand)
                   .Include(car => car.Model)
                   .Include(car => car.Color)
                   .AsNoTracking().ToList();
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}