using System.ComponentModel.DataAnnotations;

namespace Billing.Models
{
    public class Order
    {
        [Required(ErrorMessage = "OrderNumber is required.")]
        public int? OrderNumber { get; set; }
        [Required(ErrorMessage = "UserId is required.")]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "PayableAmount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "PayableAmount value must be positive.")]
        public double?  PayableAmount { get; set; }

        [Required(ErrorMessage = "PaymentGateway gateway is required.")]
        public string? PaymentGateway { get; set; }

        public string? Description { get; set; }
    }
}