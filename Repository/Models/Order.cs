using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Order
    {
        public Order()
        {
            ProductContents = new HashSet<ProductContent>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Address { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<ProductContent> ProductContents { get; set; }
    }
}
