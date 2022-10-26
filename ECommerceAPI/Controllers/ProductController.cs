using ECommerceAPI.Models;
using ECommerceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductServices _productServices;
        public ProductController(ProductServices Product)
        {
            _productServices = Product;
        }
        [HttpPost("SaveProduct")]
        public IActionResult SaveProduct(Product Product)
        {
            return Ok(_productServices.SaveProduct(Product));
        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int ProductId)
        {
            return Ok(_productServices.DeleteProduct(ProductId));
        }

        [HttpPut("UpdateProduct/{ProductId}")]
        public IActionResult UpdateProduct(int ProductId, Product Product)
        {
            return Ok(_productServices.UpdateProduct(ProductId, Product));
        }

        [HttpGet("GetProduct/{ProductId}")]
        public IActionResult GetProduct(int ProductId)
        {
            return Ok(_productServices.GetProduct(ProductId));
        }

        [HttpGet("GetAllProduct")]
        public List<Product> GetAllProduct()
        {
            return _productServices.GetAllProduct();
        }

        [HttpGet("GetByCategory")]
        public List<Product> GetByCategory(string Category)
        {
            return _productServices.GetByCategory(Category);
        }
    }
}
