﻿using CarProjectMVC.Areas.Identity.Data;
using CarProjectMVC.Models;

namespace CarProjectMVC.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с JWT токенами.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Создаёт Access Token.
        /// </summary>
        /// <param name="user">Пользователь для которого создаётся токен.</param>
        /// <returns>Access Token.</returns>
        public string CreateToken(User user);

        /// <summary>
        /// Создаёт Refresh Token.
        /// </summary>
        /// <returns>Refresh Token.</returns>
        public string CreateRefreshToken();

        /// <summary>
        /// Обновляет устаревший токен.
        /// </summary>
        /// <param name="oldToken">Устаревший токен.</param>
        /// <returns>Новый токен.</returns>
        JwtToken CreateNewToken(JwtToken oldToken);
    }
}
