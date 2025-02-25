namespace Billing.Services.PaymentGateway
{
    public interface IPaymentGateway
    {
        bool ProcessPayment(double? PayableAmount);
        string GetPaymentMethodType();
    }

    public interface IPayPalGateway : IPaymentGateway
    {
        
    }

    public interface ISwedBankGateway : IPaymentGateway
    {
        
    }

    public interface ISebGateway : IPaymentGateway
    {
        
    }
}
