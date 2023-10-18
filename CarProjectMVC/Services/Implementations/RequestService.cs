using CarProjectMVC.Areas.Identity.Data;
using CarProjectMVC.Models;
using CarProjectMVC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarProjectMVC.Services.Implementations
{
    /// <summary>
    /// Сервис для отправки запросов в БД.
    /// </summary>
    public class RequestService : IRequestService
    {
        /// <summary>
        /// Контекст для взаимодействия с БД.
        /// </summary>
        private readonly ApplicationContext _context;

        /// <summary>
        /// Инициализирует ApplicationContext.
        /// </summary>
        /// <param name="context">Контекст для взаимодействия с БД.</param>
        public RequestService(ApplicationContext context)
        {
            _context = context;
        }

        public void AddRefreshToken(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public async Task CreateAsync(IFormCollection form)
        {
            Car Auto = new()
            {
                Brand = _context.Brands.Single(brand => brand.Id == int.Parse(form["Brands"])),
                Model = _context.Models.Single(model => model.Id == int.Parse(form["Models"])),
                Color = _context.Colors.Single(color => color.Id == int.Parse(form["Colors"])),
            };
            _context.Cars.Add(Auto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(IFormCollection form)
        {
            Car Auto = new()
            {
                Id = int.Parse(form["IDs"]),
            };
            _context.Cars.Remove(Auto);
            await _context.SaveChangesAsync();
        }

        public User GetUserByToken(string refreshToken)
        {
            User? user = _context.Users.Include(user => user.Role).SingleOrDefault(u => u.RefreshToken == refreshToken);

            return user;
        }

        public List<Car> Read()
        {
            return _context.Cars.Include(car => car.Brand)
               .Include(car => car.Model)
               .Include(car => car.Color)
               .AsNoTracking().OrderBy(car => car.Id).ToList();
        }

        public Role SetDefaultRole()
        {
            //Ставим роль пользователя по умолчанию при регистрации.
            return _context.Roles.Single(role => role.Name == "Пользователь");
        }

        public async Task UpdateAsync(IFormCollection form)
        {
            Car Auto = new()
            {
                Id = int.Parse(form["IDs"]),
                Brand = _context.Brands.Single(brand => brand.Id == int.Parse(form["Brands"])),
                Model = _context.Models.Single(model => model.Id == int.Parse(form["Models"])),
                Color = _context.Colors.Single(color => color.Id == int.Parse(form["Colors"])),
            };
            _context.Cars.Update(Auto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.Include(user => user.Role).ToListAsync();
        }

        public async Task DeleteUsersAsync(IFormCollection form)
        {
            User user = new()
            {
                Id = int.Parse(form["ID"]),
                Email = form["Email"],
                Login = form["Login"],
                Password = form["Password"],
                RoleId = int.Parse(form["Roles"]),
                Role = _context.Roles.Single(color => color.Id == int.Parse(form["Roles"]))
            };
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUsersAsync(IFormCollection form)
        {
            User user = new()
            {
                Id = int.Parse(form["ID"]),
                Email = form["Email"],
                Login = form["Login"],
                Password = form["Password"],
                RoleId = int.Parse(form["Roles"]),
                Role = _context.Roles.Single(color => color.Id == int.Parse(form["Roles"]))
            };
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            List<Role> roles = await _context.Roles.ToListAsync();

            return roles;
        }
    }
}
