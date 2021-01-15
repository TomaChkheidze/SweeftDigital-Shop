using Newtonsoft.Json;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Infrastructure.Services
{
    public class CartService : ICartService
    {
        public IDataCacheService _cache;

        public CartService(IDataCacheService cache)
        {
            _cache = cache;
        }

        public async Task DeleteCartAsync(Cart cart, CancellationToken cancellationToken)
        {
            var cacheKey = GenerateCartCacheKey(cart);

            await _cache.DeleteCachedDataAsync(cacheKey, cancellationToken);
        }

        public async Task<Cart> GetCartAsync(Cart cart, CancellationToken cancelationToken)
        {
            if (string.IsNullOrEmpty(cart.Id))
            {
                return new Cart();
            }
            else
            {
                var cacheKey = $"{typeof(Cart).Name}:{cart.Id}|{ComputeSha256Hash($"{cart.Id}-{cart.Secret}")}";
                var cachedCart = await _cache.GetCachedDataAsync<Cart>(cacheKey, cancelationToken);

                return cachedCart ?? new Cart();
            }
        }

        public async Task<Cart> UpdateCartAsync(Cart cart, CancellationToken cancellationToken)
        {
            var cacheKey = GenerateCartCacheKey(cart);

            await _cache.CacheDataAsync(cacheKey, cart, TimeSpan.FromDays(2), cancellationToken);

            return cart;
        }

        private static string GenerateCartCacheKey(Cart cart)
        {
            return $"{typeof(Cart).Name}:{cart.Id}|{ComputeSha256Hash($"{cart.Id}-{cart.Secret}")}";
        }

        private static string ComputeSha256Hash(string data)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
