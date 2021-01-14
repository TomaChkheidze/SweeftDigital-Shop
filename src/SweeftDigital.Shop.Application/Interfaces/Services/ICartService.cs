using SweeftDigital.Shop.Core.Entities;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Interfaces
{
    public interface ICartService
    {
        Task<Cart> GetCartAsync(string id);
        Task<Cart> UpdateCartAsync(Cart basket);
        Task DeleteCartAsync(string id);
    }
}
