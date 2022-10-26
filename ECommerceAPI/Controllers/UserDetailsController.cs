using ECommerceAPI.Models;
using ECommerceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private UserDetailsServices _userDetailsServices;
        private IConfiguration _configuration;

        //UserDetialsController constructor
        public UserDetailsController(UserDetailsServices userDetailsServices, IConfiguration configuration)
        {
            _userDetailsServices = userDetailsServices;
            _configuration = configuration;
        }

        //Display AllUserDetails
        [HttpGet("GetAllUserDetails")]
        public List<UserDetails> GetAllUserDetails()
        {
            return _userDetailsServices.GetAllUserDetails();
        }

        //Display UserDetails using ID
        [HttpGet("GetUserDetailsbyId")]
        public IActionResult GetUserDetailsbyId(int UserId)
        {
            return Ok(_userDetailsServices.GetUserDetailsbyId(UserId));
        }

        //Display UserDetails using Email
        [HttpGet("GetUserDetailsbyEmail")]
        public IActionResult GetUserDetailsbyEmail(string Email)
        {
            return Ok(_userDetailsServices.GetUserDetailsbyEmail(Email));
        }


        //SaveDetails Function
        [HttpPost("AddUserDetails")]
        public IActionResult AddUserDetails(UserDetails userDetails)
        {
            userDetails.CreatedDate=DateTime.Now;
            return Ok(_userDetailsServices.AddUserDetails(userDetails));
        }

        //UpdateDetails function
        [HttpPut("EditUserDetails/{UserId}")]
        public async Task<IActionResult> EditUserDetails(int UserId,UserDetails userDetails)
        {
            return Ok(_userDetailsServices.EditUserDetails(UserId,userDetails));
        }

        //DeleteDetails Function
        [HttpDelete("DeleteUserDetails")]
        public IActionResult DeleteUserDetails(int UserId)
        {
            return Ok(_userDetailsServices.DeleteUserDetails(UserId));
        }

        //Login Function
        [HttpPost]
        [Route("LogIn")]
        public IActionResult LogIn(LogIn model)
        {
            var User = _userDetailsServices.GetUserDetailsbyEmail(model.EmailId);
            if (User != null && model.Password == User.Password && model.Role==User.Role)
            {
                //var tokenDescriptor = new SecurityTokenDescriptor
                //{
                //    Subject = new ClaimsIdentity(new Claim[]
                //    {
                //        new Claim("UserId", User.UserId.ToString())
                //    }),
                //    Expires = DateTime.UtcNow.AddDays(1),
                //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PNM4t3NEYbOd1SGe")),
                //    SecurityAlgorithms.HmacSha256Signature)
                //};
                //var tokenHandler = new JwtSecurityTokenHandler();
                //var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                //var Token = tokenHandler.WriteToken(securityToken);
                //return Ok(new { Token });
                string s = model.EmailId.ToString();
                return Ok(s);
            }
            else
            {
                return BadRequest(new { msg = "Incorrect Login Credentials" });
            }
        }
    }
}

