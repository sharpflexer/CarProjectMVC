using CarProjectMVC.Areas.Identity.Data;
using System.Security.Claims;

namespace CarProjectMVC.Services.Token
{
    public interface ITokenService
    {
        public string CreateToken(User user);

        public string CreateRefreshToken();

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
