using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models
{
    public class UserDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        
        [Required(ErrorMessage = "Email can not be empty")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile Number can not be empty")]
        public string MobileNumber { get; set; }

        [Required]
        public string AddressInfo { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Pincode { get; set; }

        [Required(ErrorMessage = "Password can not be empty")]
        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        
    }
}
