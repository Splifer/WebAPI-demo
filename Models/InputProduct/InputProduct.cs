using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAPI_demo.Models.Entity;

namespace WebAPI_demo.Models.InputProduct
{
    public class InputProduct
    {
        //public InputProduct() 
        //{
        //}

        [Key]
        [Column("product_id")]
        [StringLength(30)]
        public string ProductId { get; set; } = null!;

        [Column("product_name")]
        public string ProductName { get; set; } = null!;

        [Column("price", TypeName = "decimal(18, 3)")]
        public decimal Price { get; set; }

        [Column("stock")]
        public int Stock { get; set; }

        [Column("manufacturing_date", TypeName = "date")]
        public DateTime ManufacturingDate { get; set; }

        [Column("expiry_date", TypeName = "date")]
        public DateTime ExpiryDate { get; set; }

        public bool IsActive { get; set; }
    }
}
