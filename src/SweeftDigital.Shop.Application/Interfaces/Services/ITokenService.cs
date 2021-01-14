using SweeftDigital.Shop.Application.Models;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateAccessToken(ApplicationUser user);
        //string GenerateRefreshToken();
        //ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
