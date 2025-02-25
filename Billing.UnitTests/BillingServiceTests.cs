using Billing.Models;
using Billing.Services.PaymentGateway;
using Billing.Services;
using Moq;
using Billing.Services.BillingService;

namespace Billing.UnitTests
{
    public class BillingServiceTests
    {

        private readonly Mock<IReceiptService> _mockReceiptService;
        private readonly Mock<IPaymentManagerService> _mockPaymentManagerService;

        private readonly IBillingService _billingService;

        public BillingServiceTests()
        {
            _mockReceiptService = new Mock<IReceiptService>();
            _mockPaymentManagerService = new Mock<IPaymentManagerService>();
            _billingService = new BillingService(_mockReceiptService.Object, _mockPaymentManagerService.Object);
        }

        [Fact]
        public void ProcessOrder_OrderIsNull_ThrowsArgumentException()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _billingService.ProcessOrder(null));
            Assert.Equal("Invalid data.", exception.Message);
        }

        [Fact]
        public void ProcessOrder_OrderNumberIsInvalid_ThrowsArgumentException()
        {
            // Arrange
            var order = new Order
            {
                OrderNumber = null, // Invalid input
                UserId = 1,
                PayableAmount = 100.0,
                PaymentGateway = "SEB"
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _billingService.ProcessOrder(order));
            Assert.Equal("Invalid data.", exception.Message);
        }

        [Fact]
        public void ProcessOrder_UserIdIsInvalid_ThrowsArgumentException()
        {
            // Arrange
            var order = new Order
            {
                OrderNumber = 1, 
                UserId = null, // Invalid input
                PayableAmount = 100.0,
                PaymentGateway = "SEB"
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _billingService.ProcessOrder(order));
            Assert.Equal("Invalid data.", exception.Message);
        }

        [Fact]
        public void ProcessOrder_PayableAmountIsInvalid_ThrowsArgumentException()
        {
            // Arrange
            var order = new Order
            {
                OrderNumber = 1, 
                UserId = 1, 
                PayableAmount = null, // Invalid input
                PaymentGateway = "SEB"
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _billingService.ProcessOrder(order));
            Assert.Equal("Invalid data.", exception.Message);
        }

        [Fact]
        public void ProcessOrder_PayableAmountNegative_ThrowsArgumentException()
        {
            // Arrange
            var order = new Order
            {
                OrderNumber = 1,
                UserId = 1,
                PayableAmount = -100.0, //Invalid input
                PaymentGateway = "SEB"
            };
            _mockPaymentManagerService.Setup(x => x.ProcessPayment(order.PaymentGateway, order.PayableAmount)).Returns(false);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _billingService.ProcessOrder(order));
            Assert.Equal("Invalid data.", exception.Message);
        }

        [Fact]
        public void ProcessOrder_OrderIsInvalid_ThrowsArgumentExceptin()
        {
            // Arrange
            var order = new Order
            {
                OrderNumber = 1, //Invalid input
                UserId = 2, //Invalid input
                PayableAmount = 100.0,
                PaymentGateway = "SEB"
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _billingService.ProcessOrder(order));
            Assert.Equal("Invalid order.", exception.Message);
        }

        [Fact]
        public void ProcessOrder_PaymentGatewayIsInvalid_ThrowsArgumentException()
        {
            // Arrange
            var order = new Order
            {
                OrderNumber = 1,
                UserId = 1, 
                PayableAmount = 100.0,
                PaymentGateway = "invalid" //Invalid input
            };
            _mockPaymentManagerService.Setup(x => x.ProcessPayment(order.PaymentGateway, order.PayableAmount)).Returns(false);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _billingService.ProcessOrder(order));
            Assert.Equal("Invalid payment gateway.", exception.Message);
        }

        [Fact]
        public void ProcessOrder_ValidOrder_ReturnsReceipt()
        {
            // Arrange
            var order = new Order
            {
                OrderNumber = 1,
                UserId = 1,
                PayableAmount = 100.0,
                PaymentGateway = "SEB",
                Description = "Test"
            };
            var receipt = new Receipt
            {
                OrderNumber = 1,
                UserId = 1,
                AmountPaid = 100.0,
                PaymentDate = DateTime.Now
            };
            _mockPaymentManagerService.Setup(x => x.ProcessPayment(order.PaymentGateway, order.PayableAmount)).Returns(true);
            _mockReceiptService.Setup(service => service.GenerateReceipt(order)).Returns(receipt);

            // Act
            var result = _billingService.ProcessOrder(order);

            // Assert
            Assert.Equal(receipt, result);
            Assert.Equal(receipt.OrderNumber, result.OrderNumber);
            Assert.Equal(receipt.UserId, result.UserId);
            Assert.Equal(receipt.AmountPaid, result.AmountPaid);
            Assert.Equal(receipt.PaymentDate, result.PaymentDate);
        }
    }
}