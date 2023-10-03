using CarProjectMVC.Models;
using CarProjectMVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarProjectMVC.Controllers.Authorization
{
    public class LoginController : Controller
    {
        private readonly IAuthenticateService _authenticateService;
        public LoginController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Read");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(string username, string password)
        {
            var isSuccess = _authenticateService.AuthenticateUser(username, password);
            return await SignInIfSucceed(username, isSuccess);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        private async Task<IActionResult> SignInIfSucceed(string username, Task<User> isSuccess)
        {
            if (isSuccess.Result != null)
            {
                await _authenticateService.SignInAsync(HttpContext, isSuccess);

                ViewBag.username = string.Format("Successfully logged-in", username);
                TempData["username"] = username;
                return RedirectToAction("Index", "Read");
            }
            else
            {
                ViewBag.username = string.Format("Login Failed: {0}", username);
                return BadRequest("Логин и/или пароль не установлены");
            }
        }
    }
}
