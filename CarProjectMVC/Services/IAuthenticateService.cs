using CarProjectMVC.Models;

namespace CarProjectMVC.Services
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
        /// Авторизует пользователя в приложении
        /// </summary>
        /// <param name="httpContext">Информация о запросе</param>
        /// <param name="user">Аккаунт пользователя, прошедший валидацию</param>
        /// <returns></returns>
        Task SignInAsync(HttpContext httpContext, Task<User> user);

        /// <summary>
        /// Добавляет пользователя в БД при регистрации
        /// </summary>
        /// <param name="user">Аккаунт нового пользователя</param>
        void AddUser(User user);
    }
}
