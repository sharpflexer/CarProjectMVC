﻿using CarProjectMVC.Areas.Identity.Data;
using CarProjectMVC.Models;

namespace CarProjectMVC.Services.Interfaces
{
    public interface IRequestService
    {
        /// <summary>
        /// Отправляет запрос на добавление нового автомобиля в БД через ApplicationContext
        /// </summary>
        /// <param name="form">Форма с данными списков IDs, Brands, Models и Colors</param>
        /// <returns></returns>
        public Task CreateAsync(IFormCollection form);

        /// <summary>
        /// Получает список всех автомобилей из БД
        /// </summary>
        /// <returns>Список автомобилей</returns>
        public List<Car> Read();

        /// <summary>
        /// Обновляет данные автомобиля
        /// </summary>
        /// <param name="form">Форма с данными списков IDs, Brands, Models и Colors</param>
        /// <returns></returns>
        public Task UpdateAsync(IFormCollection form);

        /// <summary>
        /// Удаляет автомобиль из БД
        /// </summary>
        /// <param name="form">Форма с данными списков IDs, Brands, Models и Colors</param>
        /// <returns></returns>
        public Task DeleteAsync(IFormCollection form);

        /// <summary>
        /// Устанавливает роль пользователя по умолчанию(при регистрации)
        /// </summary>
        /// <returns></returns>
        public Role SetDefaultRole();

        /// <summary>
        /// Добавляет Refresh Token в таблицу User
        /// </summary>
        /// <param name="user">Аккаунт пользователя</param>
        /// <param name="refreshToken">Токен для обновления access token</param>
        public void AddRefreshToken(User user);
        User GetUserByToken(string refreshToken);
        Task UpdateUser(User user);
    }
}