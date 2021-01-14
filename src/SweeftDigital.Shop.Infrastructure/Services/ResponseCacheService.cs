using SweeftDigital.Shop.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Infrastructure.Services
{
    public class ResponseCacheService : IResponseCacheService
    {
        public Task CacheResponseAsync(string cacheKey, object response, TimeSpan ttl, CancellationToken cancelationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCachedResponseAsync(string cacheKey)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetCachedResponseAsync<T>(string cacheKey, CancellationToken cancelationToken)
        {
            throw new NotImplementedException();
        }
    }
}
