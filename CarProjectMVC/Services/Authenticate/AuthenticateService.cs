using CarProjectMVC.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

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
    }
}