using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Infrastructure.Services
{
    public class DataCacheService : IDataCacheService
    {
        private readonly IDistributedCache _cache;
        public DataCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task CacheDataAsync(string cacheKey, object response, TimeSpan ttl, CancellationToken cancelationToken)
        {
            if (response is null)
            {
                return;
            }

            var serialisedResponse = JsonConvert.SerializeObject(response);

            await _cache.SetStringAsync(cacheKey, serialisedResponse, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = ttl });
        }

        public async Task DeleteCachedDataAsync(string cacheKey, CancellationToken cancellationToken)
        {
            await _cache.RemoveAsync(cacheKey, cancellationToken);
        }

        public async Task<T> GetCachedDataAsync<T>(string cacheKey, CancellationToken cancelationToken)
        {
            var response = await _cache.GetStringAsync(cacheKey, cancelationToken);

            if (string.IsNullOrEmpty(response))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}
