using Microsoft.EntityFrameworkCore;
using SweeftDigital.Shop.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
