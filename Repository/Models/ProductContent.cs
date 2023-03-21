using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class ProductContent
    {
        public int Id { get; set; }
        public int? CartId { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }

        public virtual Cart? Cart { get; set; }
        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
