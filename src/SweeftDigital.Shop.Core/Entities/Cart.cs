using System;
using System.Collections.Generic;

namespace SweeftDigital.Shop.Core.Entities
{
    public class Cart
    {
        public string Id { get; set; }
        public IEnumerable<CartItem> Items { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
        }

        public Cart(string id)
            : this()
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
