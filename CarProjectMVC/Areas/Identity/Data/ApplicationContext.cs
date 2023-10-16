﻿
using CarProjectMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarProjectMVC.Areas.Identity.Data
{
    /// <summary>
    /// Контекст для взаимодействия с БД
    /// </summary>
    public class ApplicationContext : IdentityDbContext<User>
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

        /// <summary>
        /// Таблица ролей
        /// </summary>
        public DbSet<Role> Roles => Set<Role>();

        /// <summary>
        /// Таблица пользователей
        /// </summary>
        public DbSet<User> Users => Set<User>();

        /// <summary>
        /// Инициализирует контекст настройками. 
        /// Создаёт базу данных при её отсутствии
        /// и, в случае создания, заполняет данными
        /// </summary>
        /// <param name="options">Настройки контекста</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            Database.EnsureDeleted();
            if (Database.EnsureCreated())
            {
                FillDatabase();
            }
        }
        //TODO: Прочитать про ModelBuilder и добавить summary
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Role>().ToTable("Roles");
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
            builder.Ignore<IdentityUserRole<string>>();
            builder.Ignore<IdentityRole<string>>();
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
            {
                color.Models = Models.Where(model => model.Colors.Contains(color)).ToList();
            }

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

            Roles.AddRange(
                new Role()
                {
                    Name = "Админ",
                    CanCreate = true,
                    CanRead = true,
                    CanUpdate = true,
                    CanDelete = true,
                    CanManageUsers = true
                },
                new Role()
                {
                    Name = "Менеджер",
                    CanCreate = true,
                    CanRead = true,
                    CanUpdate = true,
                    CanDelete = true,
                    CanManageUsers = false
                },
                new Role()
                {
                    Name = "Пользователь",
                    CanCreate = false,
                    CanRead = true,
                    CanUpdate = false,
                    CanDelete = false,
                    CanManageUsers = false
                });
            SaveChanges();

            Users.AddRange(
                new User() { Email = "admin456@mail.ru", Login = "admin", Password = "admin123", Role = Roles.Single(role => role.Name == "Админ") },
                new User() { Email = "manager456@gmail.com", Login = "manager", Password = "manager123", Role = Roles.Single(role => role.Name == "Менеджер") },
                new User() { Email = "user456@yandex.ru", Login = "user", Password = "user123", Role = Roles.Single(role => role.Name == "Пользователь") }
            );
            SaveChanges();
        }
    }
}
