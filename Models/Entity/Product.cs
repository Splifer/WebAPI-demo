﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_demo.Models.Entity;

[Table("Product")]
public partial class Product
{
    [Key]
    [Column("product_id")]
    [StringLength(30)]
    public string ProductId { get; set; } = null!;

    [Column("product_name")]
    public string ProductName { get; set; } = null!;

    [Column("brand_name")]
    [StringLength(100)]
    public string? BrandName { get; set; }

    [Column("price", TypeName = "decimal(18, 3)")]
    public decimal Price { get; set; }

    [Column("stock")]
    public int Stock { get; set; }

    [Column("shipping_id")]
    [StringLength(30)]
    public string ShippingId { get; set; } = null!;

    [Column("payment_id")]
    [StringLength(30)]
    public string PaymentId { get; set; } = null!;

    [Column("manufacturing_date", TypeName = "date")]
    public DateTime ManufacturingDate { get; set; }

    [Column("expiry_date", TypeName = "date")]
    public DateTime ExpiryDate { get; set; }

    [Column("icon")]
    public string? Icon { get; set; } = null!;

    [Column("icon1")]
    public string? Icon1 { get; set; }

    [Column("icon2")]
    public string? Icon2 { get; set; }

    [Column("icon3")]
    public string? Icon3 { get; set; }

    [Column("icon4")]
    public string? Icon4 { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    public string? Filter { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("BrandName")]
    [InverseProperty("Products")]
    public virtual Brand? BrandNameNavigation { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [ForeignKey("PaymentId")]
    [InverseProperty("Products")]
    public virtual Payment Payment { get; set; } = null!;

    [ForeignKey("ShippingId")]
    [InverseProperty("Products")]
    public virtual Shipping Shipping { get; set; } = null!;
}
