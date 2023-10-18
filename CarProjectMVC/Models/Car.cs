namespace CarProjectMVC.Models
{
    /// <summary>
    /// Автомобиль.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Идентификатор автомобиля.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор марки автомобиля.
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// Идентификатор модели автомобиля.
        /// </summary>
        public int ModelId { get; set; }

        /// <summary>
        /// Идентификатор цвета автомобиля.
        /// </summary>
        public int ColorId { get; set; }

        /// <summary>
        /// Марка автомобиля.
        /// </summary>
        public Brand Brand { get; set; }

        /// <summary>
        /// Модель автомобиля.
        /// </summary>
        public CarModel Model { get; set; }

        /// <summary>
        /// Цвет автомобиля.
        /// </summary>
        public CarColor Color { get; set; }
    }
}
