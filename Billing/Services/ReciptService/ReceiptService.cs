using Billing.Models;
using Billing.Services.DateTimeProvider;
using System;

namespace Billing.Services.ReciptService
{
    public class ReceiptService : IReceiptService
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public ReceiptService(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public Receipt GenerateReceipt(Order order)
        {
            // Generate a receipt
            return new Receipt
            {
                OrderNumber = order.OrderNumber,
                UserId = order.UserId,
                AmountPaid = order.PayableAmount,
                PaymentDate = _dateTimeProvider.Now
            };
        }
    }
}
