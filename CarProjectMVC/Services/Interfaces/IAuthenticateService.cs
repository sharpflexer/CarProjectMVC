using CarProjectMVC.Areas.Identity.Data;

namespace CarProjectMVC.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для аутентификации пользователей.
    /// </summary>
    public interface IAuthenticateService
    {
        /// <summary>
        /// Проводит аутентификацию пользователя по логину и паролю.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <param name="password">Пароль.</param>
        /// <returns></returns>
        Task<User> AuthenticateUser(string login, string password);

        /// <summary>
        /// Удаляет куки.
        /// </summary>
        /// <param name="cookieToRevoke">Строка куки, которое нужно очистить.</param>
        void Revoke(string cookieToRevoke);
    }
}
