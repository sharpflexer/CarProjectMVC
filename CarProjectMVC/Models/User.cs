namespace CarProjectMVC.Models
{
    public class User
    {
        /// <summary>
        /// ID пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Email пользователя, указанный при регистрации
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Логин для входа
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль для входа
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Роль пользователя, дает права на различные действия с таблицей
        /// </summary>
        public Role Role { get; set; }
    }
}
