using System;
using System.Collections.Generic;

namespace SweeftDigital.Shop.Core.Entities
{
    public class Cart
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public List<CartItem> Items { get; set; }

        public Cart()
        {
            Id = Guid.NewGuid().ToString();
            Secret = Guid.NewGuid().ToString();
            Items = new List<CartItem>();
        }

        public Cart(string id, string secret) : this()
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Secret = secret ?? throw new ArgumentNullException(nameof(secret));
        }
    }
}
