using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class Order
{
    [Key]
    public int Id { get; set; }

    public int? UserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeliveryTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderDate { get; set; }

    [Unicode(false)]
    public string? Address { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<ProductContent> ProductContents { get; } = new List<ProductContent>();

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual User? User { get; set; }
}
