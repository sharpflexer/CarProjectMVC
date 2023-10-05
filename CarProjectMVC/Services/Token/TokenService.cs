using CarProjectMVC.Areas.Identity.Data;
using CarProjectMVC.Extensions;
using System.IdentityModel.Tokens.Jwt;

namespace CarProjectMVC.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(User user)
        {
            var token = user
                .CreateClaims()
                .CreateJwtToken(_configuration);
            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
