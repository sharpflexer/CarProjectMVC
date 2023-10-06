﻿using CarProjectMVC.Areas.Identity.Data;
using CarProjectMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CarProjectMVC.Services.Request
{
    public class RequestService : IRequestService
    {
        private readonly ApplicationContext _context;

        public RequestService(ApplicationContext context)
        {
            _context = context;
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
        public List<Car> Read()
        {
            return _context.Cars.Include(car => car.Brand)
               .Include(car => car.Model)
               .Include(car => car.Color)
               .AsNoTracking().OrderBy(car => car.Id).ToList();
        }

        public Role SetDefaultRole()
        {
            //Ставим роль пользователя по умолчанию при регистрации
            return _context.Roles.Single(role => role.Id == 3);
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
    }
}