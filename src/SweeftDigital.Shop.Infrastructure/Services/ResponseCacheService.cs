using Microsoft.Extensions.Caching.Distributed;
using SweeftDigital.Shop.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Infrastructure.Services
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDistributedCache _cache;
        public ResponseCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan ttl, CancellationToken cancelationToken)
        {
            if (response is null)
            {
                return;
            }

            var serialisedResponse = JsonSerializer.Serialize(response);

            await _cache.SetStringAsync(cacheKey, serialisedResponse, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = ttl });
        }

        public Task DeleteCachedResponseAsync(string cacheKey)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetCachedResponseAsync<T>(string cacheKey, CancellationToken cancelationToken)
        {
            var response = await _cache.GetStringAsync(cacheKey, cancelationToken);

            if (string.IsNullOrEmpty(response))
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(response);
        }
    }
}
