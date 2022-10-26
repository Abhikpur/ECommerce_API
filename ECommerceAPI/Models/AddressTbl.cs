using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models
{
    public class AddressTbl
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int AddressId { get; set; }

        [ForeignKey("UserDetails")]
        public int UserId { get; set; }
        public string AddressInfo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
    }
}
