using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class Category
{
    [Key]
    public int CategoryId { get; set; }

    [StringLength(50)]
    public string? CategoryName { get; set; }

    [StringLength(50)]
    public string? CategoryImageUrl { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
