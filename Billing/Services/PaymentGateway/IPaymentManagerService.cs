namespace Billing.Services.PaymentGateway
{
    public interface IPaymentManagerService
    {
        bool ProcessPayment(string? methodType, double? payableAmount);
    }
}
