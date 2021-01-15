using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Models
{
    public class CartItemOperation
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public int ItemId { get; set; }
    }
}
