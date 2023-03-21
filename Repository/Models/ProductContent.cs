using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

[Table("ProductContent")]
public partial class ProductContent
{
    [Key]
    public int Id { get; set; }

    public int? IdProduct { get; set; }

    public int? CartId { get; set; }

    public double? Price { get; set; }

    public int? Quantity { get; set; }

    public int? OrderId { get; set; }

    [ForeignKey("CartId")]
    [InverseProperty("ProductContents")]
    public virtual Cart? Cart { get; set; }

    [ForeignKey("IdProduct")]
    [InverseProperty("ProductContents")]
    public virtual Product? IdProductNavigation { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("ProductContents")]
    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
