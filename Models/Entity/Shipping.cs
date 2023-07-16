using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_demo.Models.Entity;

[Table("Shipping")]
public partial class Shipping
{
    [Key]
    [Column("shipping_id")]
    [StringLength(30)]
    public string ShippingId { get; set; } = null!;

    [Column("shipping_name")]
    public string ShippingName { get; set; } = null!;

    public string? Filter { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("Shipping")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
