using System;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Interfaces
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan ttl, CancellationToken cancelationToken);
        Task<T> GetCachedResponseAsync<T>(string cacheKey, CancellationToken cancelationToken);
        Task DeleteCachedResponseAsync(string cacheKey);
    }
}
