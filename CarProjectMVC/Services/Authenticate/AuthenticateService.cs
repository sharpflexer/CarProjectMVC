using CarProjectMVC.Areas.Identity.Data;
using CarProjectMVC.Services.Request;
using Microsoft.EntityFrameworkCore;

namespace CarProjectMVC.Services.Authenticate
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly ApplicationContext _context;
        private readonly IRequestService _requestService;

        public AuthenticateService(ApplicationContext context, IRequestService requestService)
        {
            _context = context;
            _requestService = requestService;
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

        public void Revoke(string refreshCookie)
        {
            string[] cookieParams = refreshCookie.Split(";");
            string refreshToken = cookieParams[0];

            var user = _requestService.GetUserByToken(refreshToken);
            user.RefreshToken = null;
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}