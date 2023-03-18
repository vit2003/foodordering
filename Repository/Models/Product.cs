using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    [StringLength(50)]
    public string? ProductName { get; set; }

    [StringLength(50)]
    public string? ProductImageUrl { get; set; }

    public string? ProductDescription { get; set; }

    public int? CategoryId { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }

    public bool? IsDeleted { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category? Category { get; set; }

    [InverseProperty("IdProductNavigation")]
    public virtual ICollection<ProductContent> ProductContents { get; } = new List<ProductContent>();
}
