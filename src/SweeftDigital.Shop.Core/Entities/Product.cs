using SweeftDigital.Shop.Core.Common;

namespace SweeftDigital.Shop.Core.Entities
{
    public class Product : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
    }
}
