using CarProjectMVC.Context;
using CarProjectMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CarProjectMVC.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly ApplicationContext _context;

        public AuthenticateService(ApplicationContext context)
        {
            _context = context;
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
    }
}