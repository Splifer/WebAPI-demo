using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_demo.Models.Entity;

[Table("Order")]
public partial class Order
{
    [Key]
    [Column("order_id")]
    [StringLength(30)]
    public string OrderId { get; set; } = null!;

    [Column("user_id")]
    [StringLength(30)]
    public string UserId { get; set; } = null!;

    [Column("product_id")]
    [StringLength(30)]
    public string ProductId { get; set; } = null!;

    [Column("product_count")]
    public int ProductCount { get; set; }

    [Column("order_price", TypeName = "decimal(18, 3)")]
    public decimal OrderPrice { get; set; }

    [Column("shipping_id")]
    [StringLength(30)]
    public string ShippingId { get; set; } = null!;

    [Column("payment_id")]
    [StringLength(30)]
    public string PaymentId { get; set; } = null!;

    public string? Filter { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Orders")]
    public virtual Product Product { get; set; } = null!;
}
