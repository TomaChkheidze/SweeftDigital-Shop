using SweeftDigital.Shop.Core.Common;
using SweeftDigital.Shop.Core.ValueObjects;

namespace SweeftDigital.Shop.Core.Entities
{
    public class CartItem : BaseEntity
    {
        public string Name { get; set; }
        public Money Price { get; set; }
        public int Quantity { get; set; }
    }
}
