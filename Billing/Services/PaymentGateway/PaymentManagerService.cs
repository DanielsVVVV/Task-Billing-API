using Billing.Models;
using Serilog;

namespace Billing.Services.PaymentGateway
{
    public class PaymentManagerService : IPaymentManagerService
    {
        private readonly IEnumerable<IPaymentGateway> _paymentGateways;

        public PaymentManagerService(IEnumerable<IPaymentGateway> paymentGateways)
        {
            _paymentGateways = paymentGateways;
        }

        public bool ProcessPayment(string? methodType, double? payableAmount)
        {
            var gateway = _paymentGateways.FirstOrDefault(pg => pg.GetPaymentMethodType() == methodType);

            if (gateway != null)
            {
                return gateway.ProcessPayment(payableAmount);
            }

            // Payment gateway not found
            return false;
        }



    }
    

}
