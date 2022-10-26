using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models
{
    public class LogIn
    {
        [Required(ErrorMessage = "Email can not be empty")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Password can not be empty")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Role can not be empty")]
        public string Role { get; set; }
    }
}
