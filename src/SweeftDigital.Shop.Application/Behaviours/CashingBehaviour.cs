using MediatR;
using Microsoft.Extensions.Logging;
using SweeftDigital.Shop.Application.Attributes;
using SweeftDigital.Shop.Application.Interfaces;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Behaviours
{
    public class CashingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;
        private readonly IResponseCacheService _cache;

        public CashingBehaviour(ILogger<TRequest> logger, IResponseCacheService cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var cachedAttributes = request.GetType().GetCustomAttributes<CachedAttribute>();

            if (cachedAttributes.Any())
            {
                string cacheKey = GenerateCacheKeyFromRequest(request);

                if (!string.IsNullOrEmpty(cacheKey))
                {
                    var cachedResponse = await _cache.GetCachedResponseAsync<TResponse>(cacheKey, cancellationToken);

                    if (cachedResponse != null)
                    {
                        _logger.LogInformation($"Cached Response Retrieved: {typeof(TRequest).Name} | CacheKey: {cacheKey}");
                        return cachedResponse;
                    }
                    else
                    {
                        var value = await next();

                        await _cache.CacheResponseAsync(cacheKey, value, cachedAttributes.First().Duration, cancellationToken);

                        _logger.LogInformation($"Successfully Cashed Response: {typeof(TRequest).Name} | CacheKey: {cacheKey}");

                        return value;
                    }
                }
            }

            return await next();
        }

        private string GenerateCacheKeyFromRequest(TRequest request)
        {
            var keyBuilder = new StringBuilder();

            keyBuilder.Append(typeof(TRequest).Name);

            keyBuilder.Append($"|{JsonSerializer.Serialize(request)}");

            return keyBuilder.ToString();
        }
    }
}
