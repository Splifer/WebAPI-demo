using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAPI_demo.Models.Entity;
using WebAPI_demo.Models.InputProduct;

namespace WebAPI_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly DbprojectContext _context;
        public DemoController(DbprojectContext context)
        {
            _context = context;
        }

        [HttpGet("danh-sach-san-pham")]
        public List<Product> DanhSachSanPham()
        {
            return _context.Products.ToList();
        }

        [HttpGet("danh-sach-san-pham-id")]
        public Product DanhSachSanPhamID(string id)
        {
            //if(id.IsNullOrEmpty())
            //{
            //    return new id;
            //}
            return _context.Products.FirstOrDefault(c => c.ProductId == id);
        }

        [HttpPost("them-san-pham")]
        public Product ThemSanPham([FromForm] InputProduct input)
        {
            Product product = new Product();
            product.ProductId = input.ProductId;
            product.ProductName = input.ProductName;
            product.Stock = input.Stock;
            product.Price = input.Price;
            product.ManufacturingDate = input.ManufacturingDate;
            product.ExpiryDate = input.ExpiryDate;
            product.IsActive = true;
            _context.Add(product);
            _context.SaveChanges();
            return product;
        }
    }
}
