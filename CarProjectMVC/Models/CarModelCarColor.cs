using System.ComponentModel.DataAnnotations.Schema;

namespace CarProjectMVC.Models
{
    /// <summary>
    /// Таблица для связи многие ко многим между моделями и цветами
    /// </summary>
    public class CarModelCarColor
    {
        /// <summary>
        /// ID связи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID модели
        /// </summary>
        public int ModelId { get; set; }

        /// <summary>
        /// ID цвета
        /// </summary>
        public int ColorId { get; set; }
    }
}
