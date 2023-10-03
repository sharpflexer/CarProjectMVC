﻿namespace CarProjectMVC.Models
{
    public class Brand
    {
        /// <summary>
        /// ID марки
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование марки авто
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Модели данной марки
        /// </summary>
        public ICollection<CarModel> Models { get; set; }
    }
}