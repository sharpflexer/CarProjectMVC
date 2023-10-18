using System.ComponentModel.DataAnnotations.Schema;

namespace CarProjectMVC.Models
{
    /// <summary>
    /// Таблица для связи многие ко многим между моделями и цветами.
    /// </summary>
    public class CarModelCarColor
    {
        /// <summary>
        /// Идентификатор связи.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор модели.
        /// </summary>
        public int ModelId { get; set; }

        /// <summary>
        /// Идентификатор цвета.
        /// </summary>
        public int ColorId { get; set; }
    }
}
