using CarProjectMVC.Areas.Identity.Data;
using CarProjectMVC.Services.Authenticate;
using CarProjectMVC.Services.Request;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectMVC.Controllers.Authorization
{
    public class RegisterController : Controller
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IRequestService _requestService;

        public RegisterController(IAuthenticateService authenticateService, IRequestService requestService)
        {
            _authenticateService = authenticateService;
            _requestService = requestService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(User user)
        {
            user.Role = _requestService.SetDefaultRole();
            _authenticateService.AddUser(user);
            return RedirectToAction("Index", "Login");
        }
    }
}
