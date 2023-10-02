using CarProjectMVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace CarProjectMVC.Controllers
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
            if(claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Read");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(string username, string password)
        {
            var isSuccess = _authenticateService.AuthenticateUser(username, password);

            if (isSuccess.Result != null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, username),
                    new Claim("OtherProperties", "Example Role")
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, 
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

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

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
