
using CarProjectMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarProjectMVC.Areas.Identity.Data
{
    /// <summary>
    /// Контекст для взаимодействия с БД.
    /// </summary>
    public class ApplicationContext : IdentityDbContext<User, Role, int>
    {
        /// <summary>
        /// Таблица автомобилей.
        /// </summary>
        public DbSet<Car> Cars => Set<Car>();

        /// <summary>
        /// Таблица автомобильных марок.
        /// </summary>
        public DbSet<Brand> Brands => Set<Brand>();

        /// <summary>
        /// Таблица моделей автомобилей.
        /// </summary>
        public DbSet<CarModel> Models => Set<CarModel>();

        /// <summary>
        /// Таблица расцветок автомобилей.
        /// </summary>
        public DbSet<CarColor> Colors => Set<CarColor>();

        /// <summary>
        /// Таблица ролей.
        /// </summary>
        public DbSet<Role> Roles => Set<Role>();

        /// <summary>
        /// Таблица пользователей.
        /// </summary>
        public DbSet<User> Users => Set<User>();

        /// <summary>
        /// Инициализирует контекст настройками. 
        /// Создаёт базу данных при её отсутствии
        /// и, в случае создания, заполняет данными.
        /// </summary>
        /// <param name="options">Настройки контекста.</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Настраивает и инициализирует данными БД при ее создании.
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            AssignAspNetTables(builder);
            IgnoreUselessTables(builder);

            //Инициализация базы данных стартовыми данными.
            FillDatabase(builder);
        }

        /// <summary>
        /// Привязывает сущности к уже существующим таблицам, 
        /// вместо автоматически созданных "AspNet..." таблиц.
        /// </summary>
        /// <param name="builder">Конструктор БД.</param>
        private void AssignAspNetTables(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Role>().ToTable("Roles");
        }

        /// <summary>
        /// Игнорирует ненужные таблицы при создании БД.
        /// </summary>
        /// <param name="builder">Конструктор БД.</param>
        private void IgnoreUselessTables(ModelBuilder builder)
        {
            builder.Ignore<IdentityUserClaim<int>>();
            builder.Ignore<IdentityUserToken<int>>();
            builder.Ignore<IdentityUserClaim<int>>();
            builder.Ignore<IdentityUserLogin<int>>();
            builder.Ignore<IdentityRoleClaim<int>>();
            builder.Ignore<IdentityUserRole<int>>();
            builder.Ignore<IdentityRole<int>>();
        }

        /// <summary>
        /// Инициализация базы данных стартовыми данными.
        /// </summary>
        private void FillDatabase(ModelBuilder builder)
        {
            #region Марки
            builder.Entity<Brand>().HasData(
                new Brand() { Id = 1, Name = "Audi" },
                new Brand() { Id = 2, Name = "BMW" },
                new Brand() { Id = 3, Name = "Mercedes-Benz" }
            );
            #endregion

            #region Модели
            builder.Entity<CarModel>().HasData(
                new CarModel() { Id = 1, Name = "A3", BrandId = 1 },
                new CarModel() { Id = 2, Name = "A5", BrandId = 1 },
                new CarModel() { Id = 3, Name = "A6", BrandId = 1 },
                new CarModel() { Id = 4, Name = "X3", BrandId = 2 },
                new CarModel() { Id = 5, Name = "X5", BrandId = 2 },
                new CarModel() { Id = 6, Name = "X6", BrandId = 2 },
                new CarModel() { Id = 7, Name = "GLC", BrandId = 3 },
                new CarModel() { Id = 8, Name = "GLB", BrandId = 3 },
                new CarModel() { Id = 9, Name = "GLE", BrandId = 3 }
            );
            #endregion

            #region Цвета
            builder.Entity<CarColor>().HasData(
                new CarColor { Id = 1, Name = "Red" },
                new CarColor { Id = 2, Name = "Blue" },
                new CarColor { Id = 3, Name = "Green" },
                new CarColor { Id = 4, Name = "Yellow" },
                new CarColor { Id = 5, Name = "Gray" },
                new CarColor { Id = 6, Name = "Black" },
                new CarColor { Id = 7, Name = "Dark Blue" },
                new CarColor { Id = 8, Name = "White" }
            );
            #endregion

            #region ЦветаМодели
            builder.Entity<CarModelCarColor>().HasData(
                new CarModelCarColor() { Id = 1, ModelId = 1, ColorId = 1 },
                new CarModelCarColor() { Id = 2, ModelId = 1, ColorId = 2 },
                new CarModelCarColor() { Id = 3, ModelId = 1, ColorId = 3 },

                new CarModelCarColor() { Id = 4, ModelId = 2, ColorId = 2 },
                new CarModelCarColor() { Id = 5, ModelId = 2, ColorId = 3 },
                new CarModelCarColor() { Id = 6, ModelId = 2, ColorId = 4 },

                new CarModelCarColor() { Id = 7, ModelId = 3, ColorId = 3 },
                new CarModelCarColor() { Id = 8, ModelId = 3, ColorId = 4 },
                new CarModelCarColor() { Id = 9, ModelId = 3, ColorId = 5 },

                new CarModelCarColor() { Id = 10, ModelId = 4, ColorId = 1 },
                new CarModelCarColor() { Id = 11, ModelId = 4, ColorId = 7 },
                new CarModelCarColor() { Id = 12, ModelId = 4, ColorId = 3 },

                new CarModelCarColor() { Id = 13, ModelId = 5, ColorId = 4 },
                new CarModelCarColor() { Id = 14, ModelId = 5, ColorId = 5 },
                new CarModelCarColor() { Id = 15, ModelId = 5, ColorId = 7 },

                new CarModelCarColor() { Id = 16, ModelId = 6, ColorId = 5 },
                new CarModelCarColor() { Id = 17, ModelId = 6, ColorId = 7 },
                new CarModelCarColor() { Id = 18, ModelId = 6, ColorId = 8 },

                new CarModelCarColor() { Id = 19, ModelId = 7, ColorId = 6 },
                new CarModelCarColor() { Id = 20, ModelId = 7, ColorId = 1 },
                new CarModelCarColor() { Id = 21, ModelId = 7, ColorId = 4 },

                new CarModelCarColor() { Id = 22, ModelId = 8, ColorId = 2 },
                new CarModelCarColor() { Id = 23, ModelId = 8, ColorId = 4 },
                new CarModelCarColor() { Id = 24, ModelId = 8, ColorId = 6 },

                new CarModelCarColor() { Id = 25, ModelId = 9, ColorId = 5 },
                new CarModelCarColor() { Id = 26, ModelId = 9, ColorId = 6 },
                new CarModelCarColor() { Id = 27, ModelId = 9, ColorId = 7 }
            );
            #endregion

            #region Автомобили
            builder.Entity<Car>().HasData(
                new Car()
                {
                    Id = 1,
                    BrandId = 1,
                    ModelId = 3,
                    ColorId = 3,
                },
                new Car()
                {
                    Id = 2,
                    BrandId = 2,
                    ModelId = 5,
                    ColorId = 5,
                },
                new Car()
                {
                    Id = 3,
                    BrandId = 3,
                    ModelId = 8,
                    ColorId = 4,
                });
            #endregion

            #region Роли
            builder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    Name = "Админ",
                    CanCreate = true,
                    CanRead = true,
                    CanUpdate = true,
                    CanDelete = true,
                    CanManageUsers = true
                },
                new Role()
                {
                    Id = 2,
                    Name = "Менеджер",
                    CanCreate = true,
                    CanRead = true,
                    CanUpdate = true,
                    CanDelete = true,
                    CanManageUsers = false
                },
                new Role()
                {
                    Id = 3,
                    Name = "Пользователь",
                    CanCreate = false,
                    CanRead = true,
                    CanUpdate = false,
                    CanDelete = false,
                    CanManageUsers = false
                });
            #endregion

            #region Пользователи
            builder.Entity<User>().HasData(
                new User() { Id = 1, Email = "admin456@mail.ru", Login = "admin", Password = "admin123", RoleId = 1 },
                new User() { Id = 2, Email = "manager456@gmail.com", Login = "manager", Password = "manager123", RoleId = 2 },
                new User() { Id = 3, Email = "user456@yandex.ru", Login = "user", Password = "user123", RoleId = 3 }
            );
            #endregion

        }
    }
}
