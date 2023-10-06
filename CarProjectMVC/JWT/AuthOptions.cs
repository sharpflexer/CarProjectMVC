﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CarProjectMVC.JWT
{
    public class AuthOptions
    {
        /// <summary>
        /// Издатель токена
        /// </summary>
        public const string Issuer = "http://localhost:5000";
        /// <summary>
        /// Потребитель токена
        /// </summary>
        public const string Audience = "http://localhost:5001";
        /// <summary>
        /// Ключ для создания токена
        /// </summary>
        private const string key = "carsupersecret_secretkey!123";
        /// <summary>
        /// </summary>
        /// <returns>Ключ безопасности, который применяется для генерации токена</returns>
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    }
}