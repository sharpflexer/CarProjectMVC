using CarProjectMVC.Areas.Identity.Data;
using CarProjectMVC.Extensions;
using CarProjectMVC.JWT;
using CarProjectMVC.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

namespace CarProjectMVC.Services.Implementations
{
    /// <summary>
    /// Сервис для работы с JWT токенами.
    /// </summary>
    public class TokenService : ITokenService
    {
        /// <summary>
        /// Сервис для отправки запросов в БД.
        /// </summary>
        private readonly IRequestService _requestService;

        /// <summary>
        /// Инициализирует IRequestService
        /// </summary>
        /// <param name="requestService">Сервис для отправки запросов в БД.</param>
        public TokenService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public string CreateToken(User user)
        {
            JwtSecurityToken token = user
                .CreateClaims()
                .CreateJwtToken();
            JwtSecurityTokenHandler tokenHandler = new();

            return tokenHandler.WriteToken(token);
        }

        public string CreateRefreshToken()
        {
            byte[] randomNumber = new byte[32];
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public JwtToken CreateNewToken(JwtToken oldToken)
        {
            User user = _requestService.GetUserByToken(oldToken.RefreshToken);

            string newAccessToken = "Bearer " + CreateToken(user);
            string newRefreshToken = CreateRefreshToken();

            user.RefreshToken = newRefreshToken;
            _ = _requestService.UpdateUser(user);

            return new JwtToken
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }
    }
}
