using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Core.Common;
using SweeftDigital.Shop.Core.Entities;
using SweeftDigital.Shop.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService)
            : base(options)
        {
            _currentUserService = currentUserService;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //List<Product> products = new List<Product>();

            //for (int i = 0; i < 100; i++)
            //{
            //    products.Add(
            //            new Product
            //            {
            //                Id = i + 1,
            //                Name = $"Product {i + 1}",
            //                Description = $"Product {i + 1} Description",
            //                Price = new Money(Currency.Default, 15 + i),
            //                PictureUrl = $"someurl/image{i + 1}.png"
            //            }
            //        );
            //}

            //builder.Entity<Product>().HasData(products);

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = _currentUserService.UserId;
                        entry.Entity.ModifiedAt = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
