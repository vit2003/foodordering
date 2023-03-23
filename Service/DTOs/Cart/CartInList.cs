using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Cart
{
    public class CartInList
    {
        public int CartId { get; set; }
        public string? Total { get; set; }
        public List<ProductInCartList>? Products { get; set; }
    }

    public class ProductInCartList
    {
        public int? ProductId { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
