using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class Cart
{
    [Key]
    public int CartId { get; set; }

    public int? UserId { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("Cart")]
    public virtual ICollection<ProductContent> ProductContents { get; } = new List<ProductContent>();

    [ForeignKey("UserId")]
    [InverseProperty("Carts")]
    public virtual User? User { get; set; }
}
