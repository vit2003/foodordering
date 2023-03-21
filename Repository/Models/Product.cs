using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductContents = new HashSet<ProductContent>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImageUrl { get; set; }
        public string? ProductDescription { get; set; }
        public int? CategoryId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<ProductContent> ProductContents { get; set; }
    }
}
