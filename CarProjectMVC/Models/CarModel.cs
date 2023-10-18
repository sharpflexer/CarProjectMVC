namespace CarProjectMVC.Models
{
    /// <summary>
    /// Модель автомобиля.
    /// </summary>
    public class CarModel
    {
        /// <summary>
        /// ID модели автомобиля.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование модели.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// ID марки автомобиля.
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// Цвета, доступные для данной модели.
        /// </summary>
        public ICollection<CarColor> Colors { get; set; }
    }
}