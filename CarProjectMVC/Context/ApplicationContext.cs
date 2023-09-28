using CarProjectMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CarProjectMVC.Context
{
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Таблица автомобилей
        /// </summary>
        public DbSet<Car> Cars => Set<Car>();

        /// <summary>
        /// Таблица автомобильных марок
        /// </summary>
        public DbSet<Brand> Brands => Set<Brand>();

        /// <summary>
        /// Таблица моделей автомобилей
        /// </summary>
        public DbSet<CarModel> Models => Set<CarModel>();

        /// <summary>
        /// Таблица расцветок автомобилей
        /// </summary>
        public DbSet<CarColor> Colors => Set<CarColor>();

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            if (Database.EnsureCreated())
                FillDatabase();
        }

        /// <summary>
        /// Инициализация базы данных стартовыми данными
        /// </summary>
        private void FillDatabase()
        {
            Colors.AddRange(
                new CarColor { Name = "Red" },
                new CarColor { Name = "Blue" },
                new CarColor { Name = "Green" },
                new CarColor { Name = "Yellow" },
                new CarColor { Name = "Gray" },
                new CarColor { Name = "Black" },
                new CarColor { Name = "Dark Blue" },
                new CarColor { Name = "White" });

            SaveChanges();
            Models.AddRange(
                new CarModel()
                {
                    Name = "A3",
                    Colors = new List<CarColor>() {
                        Colors.ToList().ElementAt(1),
                        Colors.ToList().ElementAt(4),
                        Colors.ToList().ElementAt(5)
                    }
                },
                new CarModel()
                {
                    Name = "A5",
                    Colors = new List<CarColor>() {
                        Colors.ToList().ElementAt(2),
                        Colors.ToList().ElementAt(4),
                        Colors.ToList().ElementAt(5)
                    }
                },
                new CarModel()
                {
                    Name = "A6",
                    Colors = new List<CarColor>() {
                        Colors.ToList().ElementAt(3),
                        Colors.ToList().ElementAt(4),
                        Colors.ToList().ElementAt(5)
                    }
                },
                new CarModel()
                {
                    Name = "X3",
                    Colors = new List<CarColor>() {
                        Colors.ToList().ElementAt(3),
                        Colors.ToList().ElementAt(1),
                        Colors.ToList().ElementAt(5)
                    }
                },
                new CarModel()
                {
                    Name = "X5",
                    Colors = new List<CarColor>() {
                        Colors.ToList().ElementAt(3),
                        Colors.ToList().ElementAt(2),
                        Colors.ToList().ElementAt(5)
                    }
                },
                new CarModel()
                {
                    Name = "X6",
                    Colors = new List<CarColor>() {
                        Colors.ToList().ElementAt(3),
                        Colors.ToList().ElementAt(6),
                        Colors.ToList().ElementAt(5)
                    }
                },
                new CarModel()
                {
                    Name = "GLE",
                    Colors = new List<CarColor>() {
                        Colors.ToList().ElementAt(1),
                        Colors.ToList().ElementAt(6),
                        Colors.ToList().ElementAt(2)
                    }
                },
                new CarModel()
                {
                    Name = "GLB",
                    Colors = new List<CarColor>() {
                        Colors.ToList().ElementAt(1),
                        Colors.ToList().ElementAt(4),
                        Colors.ToList().ElementAt(5)
                    }
                },
                new CarModel()
                {
                    Name = "GLC",
                    Colors = new List<CarColor>() {
                        Colors.ToList().ElementAt(1),
                        Colors.ToList().ElementAt(2),
                        Colors.ToList().ElementAt(3)
                    }
                }
            );
            SaveChanges();

            foreach (CarColor color in Colors.ToList())
                color.Models = Models.Where(model => model.Colors.Contains(color)).ToList();

            SaveChanges();
            Brands.AddRange(
                new Brand()
                {
                    Name = "Audi",
                    Models = Models.ToList().Where(m => m.Name.Contains('A')).ToList(),
                },
                new Brand()
                {
                    Name = "BMW",
                    Models = Models.ToList().Where(m => m.Name.Contains('X')).ToList(),
                },
                new Brand()
                {
                    Name = "Mercedes-Benz",
                    Models = Models.ToList().Where(m => m.Name.Contains("GL")).ToList(),
                }
            );
            SaveChanges();
        }
    }
}
