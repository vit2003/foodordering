using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Cart
    {
        public Cart()
        {
            ProductContents = new HashSet<ProductContent>();
        }

        public int CartId { get; set; }
        public int? UserId { get; set; }
        public bool? IsActive { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<ProductContent> ProductContents { get; set; }
    }
}
