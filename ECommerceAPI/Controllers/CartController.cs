using ECommerceAPI.Models;
using ECommerceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private CartServices _cartServices;
        public CartController(CartServices cartServices)
        {
            _cartServices = cartServices;
        }
        [HttpPost("SaveCart")]
        public IActionResult SaveCart(Cart cart)
        {
            return Ok(_cartServices.SaveCart(cart));
        }

        [HttpDelete("DeleteCart")]
        public IActionResult DeleteCart(int CartId)
        {
            return Ok(_cartServices.DeleteCart(CartId));
        }

        [HttpPut("UpdateCart")]
        public IActionResult UpdateCart(Cart cart)
        {
            return Ok(_cartServices.UpdateCart(cart));
        }

        [HttpGet("GetCart")]
        public IActionResult GetCart(int CartId)
        {
            return Ok(_cartServices.GetCart(CartId));
        }

        [HttpGet("GetAllCart")]
        public List<Cart> GetAllCart()
        {
            return _cartServices.GetAllCart();
        }

        [HttpGet("GetCartHistory")]
        public IActionResult GetCartByUserID(int UserId)
        {
            return Ok(_cartServices.GetCartByUserID(UserId));
        }
        [HttpGet("GetCartId")]
        public IActionResult GetCartId(int UserId)
        {
            return Ok(_cartServices.GetCartId(UserId));
        }

    }
}
