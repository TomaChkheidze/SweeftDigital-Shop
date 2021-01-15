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

        public Task CreateAsync(Product item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetAsync(int id, CancellationToken? cancellationToken)
        {
            return await _context.Products.FindAsync(id);
        }

        public Task<IEnumerable<Product>> GetAllAsync(CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<Product>> GetPaginatedAsync(int pageIndex, int pageSize, CancellationToken cancelationToken)
        {
            return await PaginatedList<Product>.CreateAsync(_context.Products.AsQueryable(), pageIndex, pageSize, cancelationToken);
        }

        public Task UpdateAsync(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
