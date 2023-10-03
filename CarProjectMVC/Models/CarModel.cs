namespace CarProjectMVC.Models
{
    public class CarModel
    {
        /// <summary>
        /// ID модели автомобиля
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование модели
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цвета, доступные для данной модели
        /// </summary>
        public ICollection<CarColor> Colors { get; set; }
    }
}