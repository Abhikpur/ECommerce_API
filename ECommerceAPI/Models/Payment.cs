using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }
        public decimal TransactionAmount { get; set; }

        [ForeignKey("UserDetails")]
        public int UserId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public string TransactionStatus { get; set; }
        public string PaymentMode { get; set; }
        public string DiscountCode { get; set; }

    }
}
