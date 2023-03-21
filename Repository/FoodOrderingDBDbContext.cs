using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Repository.Models;

namespace Repository
{
    public partial class FoodOrderingDBDbContext : DbContext
    {
        public FoodOrderingDBDbContext()
        {
        }

        public FoodOrderingDBDbContext(DbContextOptions<FoodOrderingDBDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductContent> ProductContents { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=database-1.cnzixon2mwyb.ap-southeast-1.rds.amazonaws.com;Database=FoodOrderingDB;user id=admin;password=12345678;Trusted_Connection=false;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_users_carts");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryImageUrl).HasMaxLength(50);

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.DeliveryTime).HasColumnType("datetime");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Orders_Users");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductImageUrl).HasMaxLength(50);

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("fk_product_category");
            });

            modelBuilder.Entity<ProductContent>(entity =>
            {
                entity.ToTable("ProductContent");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.ProductContents)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("fk_productcontent_carts");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProductContents)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_ProductContent_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductContents)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.AddressUser).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.ImageUrl).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(11);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("fk_users_roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
