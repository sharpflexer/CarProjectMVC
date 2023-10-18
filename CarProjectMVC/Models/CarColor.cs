namespace CarProjectMVC.Models
{
    /// <summary>
    /// Цвет автомобиля.
    /// </summary>
    public class CarColor
    {
        /// <summary>
        /// ID цвета.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование цвета.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список моделей данного цвета.
        /// </summary>
        public ICollection<CarModel> Models { get; set; }
    }
}