using System;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Interfaces
{
    public interface IDataCacheService
    {
        Task CacheDataAsync(string cacheKey, object response, TimeSpan ttl, CancellationToken cancelationToken);
        Task<T> GetCachedDataAsync<T>(string cacheKey, CancellationToken cancelationToken);
        Task DeleteCachedDataAsync(string cacheKey, CancellationToken cancellationToken);
    }
}
