namespace CarProjectMVC.Models
{
    /// <summary>
    /// Автомобиль
    /// </summary>
    public class Car
    {
        /// <summary>
        /// ID автомобиля
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID марки автомобиля
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// ID модели автомобиля
        /// </summary>
        public int ModelId { get; set; }

        /// <summary>
        /// ID цвета автомобиля
        /// </summary>
        public int ColorId { get; set; }

        /// <summary>
        /// Марка автомобиля
        /// </summary>
        public Brand Brand { get; set; }

        /// <summary>
        /// Модель автомобиля
        /// </summary>
        public CarModel Model { get; set; }

        /// <summary>
        /// Цвет автомобиля
        /// </summary>
        public CarColor Color { get; set; }
    }
}
