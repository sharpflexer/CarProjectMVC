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
        ApplicationContext _context;
        IRequestService _requestService;

        public ReadController(ApplicationContext context, IRequestService requestService)
        {
            _context = context;
            _requestService = requestService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            ViewData["cars"] = _requestService.ReadAsync();
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}