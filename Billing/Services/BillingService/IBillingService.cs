using Billing.Models;

namespace Billing.Services.BillingService
{
    public interface IBillingService
    {
        public Receipt ProcessOrder(Order order);
    }
}
