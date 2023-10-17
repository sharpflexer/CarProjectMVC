namespace CarProjectMVC.Models
{
    /// <summary>
    /// Ошибка
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// ID запроса
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Статус отображения ID запроса
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}