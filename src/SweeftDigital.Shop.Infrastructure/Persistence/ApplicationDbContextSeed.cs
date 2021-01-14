using SweeftDigital.Shop.Core.Entities;
using SweeftDigital.Shop.Core.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedData(ApplicationDbContext context)
        {
            if (!context.Products.Any())
            {
                List<Product> products = new List<Product>();

                for (int i = 0; i < 100; i++)
                {
                    products.Add(
                            new Product
                            {
                                Name = $"Product {i + 1}",
                                Description = $"Product {i + 1} Description",
                                Price = new Money(Currency.Default, 15 + i),
                                PictureUrl = $"someurl/image{i + 1}.png"
                            }
                        );
                }

                context.Products.AddRange(products);
                await context.SaveChangesAsync(new System.Threading.CancellationToken());
            }
        }
    }
}
