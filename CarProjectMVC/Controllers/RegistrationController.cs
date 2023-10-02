using Microsoft.AspNetCore.Mvc;

namespace CarProjectMVC.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
