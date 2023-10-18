using CarProjectMVC.Areas.Identity.Data;
using CarProjectMVC.Services.Interfaces;

namespace CarProjectMVC.Services.Implementations
{
    /// <summary>
    /// Сервис для аутентификации пользователей.
    /// </summary>
    public class AuthenticateService : IAuthenticateService
    {
        /// <summary>
        /// Сервис для отправки запросов в БД.
        /// </summary>
        private readonly IRequestService _requestService;

        /// <summary>
        /// Инициализирует сервис requestService.
        /// </summary>
        /// <param name="requestService">Сервис для отправки запросов в БД.</param>
        public AuthenticateService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// Проводит аутентификацию пользователя по логину и паролю.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <param name="password">Пароль.</param>
        /// <returns>Аутентифицированный пользователь.</returns>
        public async Task<User> AuthenticateUser(string login, string password)
        {
            var users = await _requestService.GetUsers();
            var currentUser = users.FirstOrDefault(authUser => authUser.Login == login &&
                                                                                 authUser.Password == password);
            return currentUser;
        }

        /// <summary>
        /// Удаляет куки.
        /// </summary>
        /// <param name="cookieToRevoke">Строка куки, которое нужно очистить.</param>
        public void Revoke(string cookieToRevoke)
        {
            string[] cookieParams = cookieToRevoke.Split(";");
            string refreshToken = cookieParams[0];

            var user = _requestService.GetUserByToken(refreshToken);
            user.RefreshToken = null;

            _requestService.UpdateUser(user);
        }
    }
}