using Microsoft.AspNetCore.Identity;

namespace CarProjectMVC.Areas.Identity.Data
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User : IdentityUser<int>
    {
        /// <summary>
        /// Email пользователя, указанный при регистрации.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Логин для входа.
        /// </summary>
        public required string Login { get; set; }

        /// <summary>
        /// Пароль для входа.
        /// </summary>
        public required string Password { get; set; }

        /// <summary>
        /// Идентификатор роли пользователя.
        /// </summary> 
        public required int RoleId { get; set; }

        /// <summary>
        /// Роль пользователя, дает права на различные действия с таблицей.
        /// </summary> 
        public Role Role { get; set; }

        /// <summary>
        /// Токен для обновления Access Token.
        /// </summary>
        public string? RefreshToken { get; set; }
    }
}
