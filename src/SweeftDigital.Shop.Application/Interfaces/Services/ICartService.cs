using SweeftDigital.Shop.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Interfaces
{
    public interface ICartService
    {
        Task<Cart> GetCartAsync(Cart cart, CancellationToken cancellationToken);
        Task<Cart> UpdateCartAsync(Cart cart, CancellationToken cancellationToken);
        Task DeleteCartAsync(Cart cart, CancellationToken cancellationToken);
    }
}
