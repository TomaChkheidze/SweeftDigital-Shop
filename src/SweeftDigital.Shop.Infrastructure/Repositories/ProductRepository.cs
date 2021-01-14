using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Application.Models;
using SweeftDigital.Shop.Core.Entities;
using SweeftDigital.Shop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Create(Product item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Get(int id, CancellationToken? cancellationToken)
        {
            return await _context.Products.FindAsync(id);
        }

        public Task<IEnumerable<Product>> GetAll(CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<Product>> GetPaginated(int pageIndex, int pageSize, CancellationToken cancelationToken)
        {
            return await PaginatedList<Product>.CreateAsync(_context.Products.AsQueryable(), pageIndex, pageSize, cancelationToken);
        }

        public Task Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
