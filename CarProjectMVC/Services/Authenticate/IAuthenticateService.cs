using CarProjectMVC.Areas.Identity.Data;

namespace CarProjectMVC.Services.Authenticate
{
    public interface IAuthenticateService
    {
        /// <summary>
        /// Получает список всех пользователей из БД
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<User>> GetUsers();

        /// <summary>
        /// Проводит аутентификацию пользователя по логину и паролю
        /// </summary>
        /// <param name="username">Логин</param>
        /// <param name="passcode">Пароль</param>
        /// <returns></returns>
        Task<User> AuthenticateUser(string username, string passcode);

        /// <summary>
        /// Добавляет пользователя в БД при регистрации
        /// </summary>
        /// <param name="user">Аккаунт нового пользователя</param>
        void AddUser(User user);
        void Revoke(string refreshCookie);
    }
}
