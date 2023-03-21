using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace FoodOrderingAPI.Repository;

public partial class FoodOrderingDBDbContext : DbContext
{
    public FoodOrderingDBDbContext()
    {
    }

    public FoodOrderingDBDbContext(DbContextOptions<FoodOrderingDBDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductContent> ProductContents { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=database-1.cnzixon2mwyb.ap-southeast-1.rds.amazonaws.com;Database=FoodOrderingDB;user id=admin;password=12345678;Trusted_Connection=False;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Carts__51BCD7B784E26D25");

            entity.Property(e => e.CartId).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.Carts).HasConstraintName("fk_users_carts");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0B79E54688");

            entity.Property(e => e.CategoryId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__D3B9D36C1C97397D");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.Orders).HasConstraintName("FK_Orders_Users");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CD537152F6");

            entity.Property(e => e.ProductId).ValueGeneratedNever();

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("fk_product_category");
        });

        modelBuilder.Entity<ProductContent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductC__B7703B3E5C7318C6");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Cart).WithMany(p => p.ProductContents).HasConstraintName("fk_productcontent_carts");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductContents).HasConstraintName("FK_ProductContent_Products");

            entity.HasOne(d => d.Order).WithMany(p => p.ProductContents).HasConstraintName("FK_ProductContent_Orders");
            
            entity.HasOne(d => d.Product).WithMany(p => p.ProductContents).HasConstraintName("FK_ProductContent_Product");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1AAD7D7C3D");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__1788CC4CAF5D7429");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Role).WithMany(p => p.Users).HasConstraintName("fk_users_roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
