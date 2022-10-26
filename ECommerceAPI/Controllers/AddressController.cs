using ECommerceAPI.Models;
using ECommerceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private AddressServices _addServices;
        public AddressController(AddressServices addServices)
        {
            _addServices = addServices;
        }
        [HttpPost("SaveAddress")]
        public IActionResult SaveAddress(AddressTbl AddressT)
        {
            return Ok(_addServices.SaveAddress(AddressT));
        }

        [HttpDelete("DeleteAddress")]
        public IActionResult DeleteAddress(int AddressId)
        {
            return Ok(_addServices.DeleteAddress(AddressId));
        }

        [HttpPut("UpdateAddress")]
        public IActionResult UpdateAddress(AddressTbl AddressT)
        {
            return Ok(_addServices.UpdateAddress(AddressT));
        }

        [HttpGet("GetAddress")]
        public IActionResult GetAddress(int AddressId)
        {
            return Ok(_addServices.GetAddress(AddressId));
        }

        [HttpGet("GetUserAddress")]
        public IActionResult GetUserAddress(int UserId)
        {
            return Ok(_addServices.GetUserAddress(UserId));
        }

        [HttpGet("GetAllAddress")]
        public List<AddressTbl> GetAllAddress()
        {
            return _addServices.GetAllAddress();
        }
    }
}
