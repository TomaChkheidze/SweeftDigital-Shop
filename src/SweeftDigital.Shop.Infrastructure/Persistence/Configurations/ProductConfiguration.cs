using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweeftDigital.Shop.Core.Entities;
using SweeftDigital.Shop.Core.ValueObjects;

namespace SweeftDigital.Shop.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.OwnsOne(x => x.Price)
                .Property(x => x.Quantity).HasPrecision(14, 2);
            builder.OwnsOne(x => x.Price)
                .Property(x => x.Currency).HasConversion(x => x.Code, x => new Currency(x));
        }
    }
}
