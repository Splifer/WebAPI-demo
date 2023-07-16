using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_demo.Models.Entity;

public partial class DbprojectContext : DbContext
{
    public DbprojectContext()
    {
    }

    public DbprojectContext(DbContextOptions<DbprojectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Shipping> Shippings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=connectString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasOne(d => d.GenderNameNavigation).WithMany(p => p.Accounts).HasConstraintName("FK_Account_Gender");

            entity.HasOne(d => d.RoleNameNavigation).WithMany(p => p.Accounts).HasConstraintName("FK_Account_Role");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(d => d.Product).WithMany(p => p.Orders).HasConstraintName("FK_Order_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasOne(d => d.BrandNameNavigation).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Product_Brand");

            entity.HasOne(d => d.Payment).WithMany(p => p.Products).HasConstraintName("FK_Product_Payment");

            entity.HasOne(d => d.Shipping).WithMany(p => p.Products).HasConstraintName("FK_Product_Shipping");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
