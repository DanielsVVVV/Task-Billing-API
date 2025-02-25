using Billing.Models;

namespace Billing.Services
{
    public interface IReceiptService
    {
        Receipt GenerateReceipt(Order order);
    }
}