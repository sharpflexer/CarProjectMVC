namespace CarProjectMVC.Models
{
    public class Car
    {
        /// <summary>
        /// ID автомобиля
        /// </summary>
        public int Id { get; set; }

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
