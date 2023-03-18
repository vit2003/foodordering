using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class User
{
    [Key]
    public int Id { get; set; }

    public int? RoleId { get; set; }

    [StringLength(50)]
    public string? FullName { get; set; }

    [StringLength(50)]
    public string? UserName { get; set; }

    [StringLength(11)]
    public string? Mobile { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    [StringLength(50)]
    public string? AddressUser { get; set; }

    [StringLength(50)]
    public string? Password { get; set; }

    [StringLength(50)]
    public string? ImageUrl { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    [InverseProperty("User")]
    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role? Role { get; set; }
}
