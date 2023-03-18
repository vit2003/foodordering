using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Product
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImageUrl { get; set; }
        public string? ProductDescription { get; set; }
        public int? CategoryId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
    }
}
