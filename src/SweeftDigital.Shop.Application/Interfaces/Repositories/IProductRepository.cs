using SweeftDigital.Shop.Application.Models;
using SweeftDigital.Shop.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
    }
}
