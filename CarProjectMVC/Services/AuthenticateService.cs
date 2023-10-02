﻿using CarProjectMVC.Context;
using CarProjectMVC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectMVC.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly ApplicationContext _context;

        public AuthenticateService(ApplicationContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task<User> AuthenticateUser(string login, string password)
        {
            var succeeded = await _context.Users.FirstOrDefaultAsync(authUser => authUser.Login == login &&
                                                                                 authUser.Password == password);
            return succeeded;
        }

        public async Task<IEnumerable<User>> GetUser()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task SignInAsync(HttpContext httpContext, string username)
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

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), properties);
        }
    }
}