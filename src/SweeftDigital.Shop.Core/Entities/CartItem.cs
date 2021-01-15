using SweeftDigital.Shop.Core.Common;

namespace SweeftDigital.Shop.Core.Entities
{
    public class CartItem : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
