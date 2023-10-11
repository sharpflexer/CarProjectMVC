using CarProjectMVC.Areas.Identity.Data;
using CarProjectMVC.JWT;
using System.Security.Claims;

namespace CarProjectMVC.Services.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(User user);

        public string CreateRefreshToken();

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        JwtToken CreateNewToken(JwtToken tokenApiModel);
    }
}
