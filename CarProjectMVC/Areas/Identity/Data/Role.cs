namespace CarProjectMVC.Areas.Identity.Data
{
    /// <summary>
    /// Роль пользователя
    /// </summary>
    public class Role
    {
        /// <summary>
        /// ID роли
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название роли
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Право на создание записей
        /// </summary>
        public bool CanCreate { get; set; }

        /// <summary>
        /// Право на чтение записей
        /// </summary
        public bool CanRead { get; set; }

        /// <summary>
        /// Право на обновление записей
        /// </summary
        public bool CanUpdate { get; set; }

        /// <summary>
        /// Право на удаление записей
        /// </summary
        public bool CanDelete { get; set; }

        /// <summary>
        /// Право на чтение и изменение данных пользователей
        /// </summary>
        public bool CanManageUsers { get; set; }
    }
}
