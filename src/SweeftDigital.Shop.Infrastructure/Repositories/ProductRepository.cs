using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Application.Models;
using SweeftDigital.Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task Create(Product item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Get(int id, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll(CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<Product>> GetPaginated(int pageIndex, int pageSize, CancellationToken cancelationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
