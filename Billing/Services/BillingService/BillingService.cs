using Billing.Models;
using Billing.Services.PaymentGateway;
using Serilog;

namespace Billing.Services.BillingService
{
    public class BillingService : IBillingService
    {
        private readonly IReceiptService _receiptService;
        private readonly IPaymentManagerService _paymentManagerService;

        public BillingService(IReceiptService receiptService, IPaymentManagerService paymentManagerService)
        {
            _receiptService = receiptService;
            _paymentManagerService = paymentManagerService;
        }

        public Receipt ProcessOrder(Order order)
        {            
            try
            {
                Log.Information("Processing order...: {@order}", order);

                //Check if is valid input
                if (order == null || !IsValidOrderInput(order))
                {
                    throw new ArgumentException("Invalid data.");
                }

                //check if the given user has the rights order
                var checkOder = IsOrderValid(order.OrderNumber, order.UserId);

                //if the order is not valid
                if (!checkOder)
                {
                    throw new ArgumentException("Invalid order.");
                }

                //check if the payment gateway is valid
                var paymentGateway = _paymentManagerService.ProcessPayment(order.PaymentGateway, order.PayableAmount);
                if (!paymentGateway)
                {
                    throw new ArgumentException("Invalid payment gateway.");
                }

                //return the receipt
                var receipt = _receiptService.GenerateReceipt(order);
                return receipt;
            }
            catch (ArgumentException ex)
            {
                Log.Information(ex.Message);
                throw new ArgumentException(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error on ProcessOrder function");
                throw new ArgumentException("Internal server error.");
            }
        }

        private bool IsOrderValid(int? orderNumber, int? userId)
        {
            
            //check if the given user has the right order
            //call the database to check if the order is valid, but for testing purposes, we will return true if both is same;
            int? order = orderNumber;
            if (orderNumber != userId)
            {
                order = null;
            }

            if (order == null)
            {
                return false;
            }
            return true;
            
        }

        private bool IsValidOrderInput(Order order)
        {
            // Check Req Order
            if (order.OrderNumber == null || order.UserId == null || order.PayableAmount == null || string.IsNullOrEmpty(order.PaymentGateway) || order.PayableAmount < 0)
            {
                return false;
            }
            return true;
        }


    }
}
