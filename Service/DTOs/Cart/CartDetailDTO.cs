using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Cart
{
    public class CartDetailDTO
    {
        public int CartId { get; set; }
        public List<ProductInCart> Products { get; set; }
        public string? Total { get; set; }
    }
    public class ProductInCart
    {
        public int? ProductId { get; set;}
        public string? Name { get; set; }
        public string? PricePerOne { get; set; }
        public int? Quantity { get; set; }
        public string? AllPrize { get; set; }
    }
}
