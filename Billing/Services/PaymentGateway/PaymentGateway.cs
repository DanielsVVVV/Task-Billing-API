using Billing.Models;
using Serilog;

namespace Billing.Services.PaymentGateway
{
    public class PayPalGateway : IPayPalGateway
    {
        public string GetPaymentMethodType() => "PayPal";

        public bool ProcessPayment(double? amount)
        {
            if (amount < 0)
            {
                Log.Information("Failed PayPal payment...");
                return false;
            }

            Log.Information("Processing PayPal payment...");
            return true;
        }
    }

    public class SwedBankGateway : ISwedBankGateway
    {
        public string GetPaymentMethodType() => "SwedBank";

        public bool ProcessPayment(double? amount)
        {
            if (amount < 0)
            {
                Log.Information("Failed SwedBank payment...");
                return false;
            }

            Log.Information("Processing SwedBank payment...");
            return true;
        }
    }

    public class SebGateway : ISebGateway
    {
        public string GetPaymentMethodType() => "SEB";
        public bool ProcessPayment(double? amount)
        {
            if (amount < 0)
            {
                Log.Information("Failed SEB payment...");
                return false;
            }

            Log.Information("Processing SEB payment...");
            return true;
        }
    }

}
