using CarProjectMVC.Areas.Identity.Data;

namespace CarProjectMVC.Services.Token
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
