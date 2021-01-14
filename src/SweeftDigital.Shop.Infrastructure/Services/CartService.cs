using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Infrastructure.Services
{
    public class CartService : ICartService
    {
        public Task DeleteCartAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetCartAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> UpdateCartAsync(Cart basket)
        {
            throw new NotImplementedException();
        }
    }
}
