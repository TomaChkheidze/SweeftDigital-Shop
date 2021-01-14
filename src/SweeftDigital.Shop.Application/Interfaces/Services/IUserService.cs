using SweeftDigital.Shop.Application.Handlers.Account.Commands;
using SweeftDigital.Shop.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> LoginUserAsync(string username, string password);
        Task<IEnumerable<string>> GetUserRolesAsync(ApplicationUser user);
        Task<bool> RegisterUserAsync(RegisterCommand command);
        Task<string> GetUserNameAsync(string userId);
    }
}
