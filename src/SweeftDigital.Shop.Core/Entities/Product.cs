using SweeftDigital.Shop.Core.Common;
using SweeftDigital.Shop.Core.ValueObjects;

namespace SweeftDigital.Shop.Core.Entities
{
    public class Product : AuditableEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Money Price { get; set; }
        public string PictureUrl { get; set; }
    }
}
