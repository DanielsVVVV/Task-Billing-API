using System.ComponentModel.DataAnnotations;

namespace Billing.Models
{
    public class Receipt
    {
        [Required]
        public int? OrderNumber { get; set; }
        [Required]
        public int? UserId { get; set; }
        [Required]
        public double? AmountPaid { get; set; }
        [Required]
        public DateTime? PaymentDate { get; set; }

    }
}
