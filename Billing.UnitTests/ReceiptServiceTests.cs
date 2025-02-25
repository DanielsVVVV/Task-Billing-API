using Billing.Models;
using Moq;
using Billing.Services;
using Billing.Services.ReciptService;
using Billing.Services.DateTimeProvider;

namespace Billing.UnitTests
{
    public class ReceiptServiceTests
    {
        private readonly Mock<IDateTimeProvider> _mockDateTimeProvider;
        private readonly IReceiptService _receiptService;

        public ReceiptServiceTests()
        {
            _mockDateTimeProvider = new Mock<IDateTimeProvider>();
            _receiptService = new ReceiptService(_mockDateTimeProvider.Object);
        }        

        [Fact]
        public void GenerateReceipt_ReturnsReceipt()
        {
            // Arrange
            var order = new Order
            {
                OrderNumber = 1,
                UserId = 1,
                PayableAmount = 100.0,
                PaymentGateway = "SEB"
            };
            var fixedDateTime = new DateTime(2025, 2, 25);
            _mockDateTimeProvider.Setup(x => x.Now).Returns(fixedDateTime);

            // Act
            var result = _receiptService.GenerateReceipt(order);

            // Assert
            Assert.Equal(fixedDateTime, result.PaymentDate);
            Assert.Equal(order.OrderNumber, result.OrderNumber);
            Assert.Equal(order.UserId, result.UserId);
            Assert.Equal(order.PayableAmount, result.AmountPaid);
        }
    }
}