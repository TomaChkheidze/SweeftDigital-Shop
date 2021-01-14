using SweeftDigital.Shop.Application.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> Get(int id, CancellationToken? cancellationToken);
        Task<IEnumerable<T>> GetAll(CancellationToken? cancellationToken);
        Task<PaginatedList<T>> GetPaginated(int pageIndex, int pageSize, CancellationToken cancelationToken);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
    }
}
