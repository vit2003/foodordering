using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryImageUrl { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
