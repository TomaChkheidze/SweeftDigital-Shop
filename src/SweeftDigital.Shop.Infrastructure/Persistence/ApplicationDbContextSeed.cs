using SweeftDigital.Shop.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static void SeedData(ApplicationDbContext context)
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
                                Price = 15 + i,
                                PictureUrl = $"someurl/image{i + 1}.png"
                            }
                        );
                }

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
