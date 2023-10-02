using CarProjectMVC.Models;

namespace CarProjectMVC.Services
{
    public interface IAuthenticateService
    {
        Task<IEnumerable<User>> GetUser();
        Task<User> AuthenticateUser(string username, string passcode);
        Task SignInAsync(HttpContext httpContext, string username);
        void AddUser(User user);
    }
}
