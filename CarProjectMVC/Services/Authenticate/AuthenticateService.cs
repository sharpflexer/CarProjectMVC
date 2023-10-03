using CarProjectMVC.Context;
using CarProjectMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarProjectMVC.Services.Authenticate
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
            var succeeded = await _context.Users.Include(user => user.Role)
                                                .FirstOrDefaultAsync(authUser => authUser.Login == login &&
                                                                                 authUser.Password == password);
            return succeeded;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task SignInAsync(HttpContext httpContext, Task<User> user)
        {
            List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Result.Login),
                    new Claim("CanCreate", user.Result.Role.CanCreate.ToString()),
                    new Claim("CanRead", user.Result.Role.CanRead.ToString()),
                    new Claim("CanUpdate", user.Result.Role.CanUpdate.ToString()),
                    new Claim("CanDelete", user.Result.Role.CanDelete.ToString())
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