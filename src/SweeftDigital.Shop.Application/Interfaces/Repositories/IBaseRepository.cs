using SweeftDigital.Shop.Application.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> GetAsync(int id, CancellationToken? cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken? cancellationToken);
        Task<PaginatedList<T>> GetPaginatedAsync(int pageIndex, int pageSize, CancellationToken cancelationToken);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
    }
}
