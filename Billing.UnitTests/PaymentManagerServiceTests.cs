using Moq;
using Billing.Services.PaymentGateway;

namespace Billing.UnitTests
{
    public class PaymentManagerServiceTests
    {

        private readonly Mock<IPaymentGateway> _mockPayPalGateway;
        private readonly Mock<IPaymentGateway> _mockSwedBankGateway;
        private readonly Mock<IPaymentGateway> _mockSebGateway;
        private readonly PaymentManagerService _paymentManagerService;

        public PaymentManagerServiceTests()
        {
            _mockPayPalGateway = new Mock<IPaymentGateway>();
            _mockSwedBankGateway = new Mock<IPaymentGateway>();
            _mockSebGateway = new Mock<IPaymentGateway>();

            var paymentGateways = new List<IPaymentGateway>
            {
                _mockPayPalGateway.Object,
                _mockSwedBankGateway.Object,
                _mockSebGateway.Object
            };

            _paymentManagerService = new PaymentManagerService(paymentGateways);
        }

        [Fact]
        public void ProcessPayment_ValidPayPalPayment_ReturnsTrue()
        {
            // Arrange
            var methodType = "PayPal";
            var payableAmount = 100.0;
            _mockPayPalGateway.Setup(pg => pg.GetPaymentMethodType()).Returns(methodType);
            _mockPayPalGateway.Setup(pg => pg.ProcessPayment(payableAmount)).Returns(true);

            // Act
            var result = _paymentManagerService.ProcessPayment(methodType, payableAmount);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ProcessPayment_ValidSwedBankPayment_ReturnsTrue()
        {
            // Arrange
            var methodType = "SwedBank";
            var payableAmount = 100.0;
            _mockSwedBankGateway.Setup(pg => pg.GetPaymentMethodType()).Returns(methodType);
            _mockSwedBankGateway.Setup(pg => pg.ProcessPayment(payableAmount)).Returns(true);

            // Act
            var result = _paymentManagerService.ProcessPayment(methodType, payableAmount);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ProcessPayment_ValidSebPayment_ReturnsTrue()
        {
            // Arrange
            var methodType = "SEB";
            var payableAmount = 100.0;
            _mockSebGateway.Setup(pg => pg.GetPaymentMethodType()).Returns(methodType);
            _mockSebGateway.Setup(pg => pg.ProcessPayment(payableAmount)).Returns(true);

            // Act
            var result = _paymentManagerService.ProcessPayment(methodType, payableAmount);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ProcessPayment_InvalidPaymentGateway_ReturnsFalse()
        {
            // Arrange
            var methodType = "InvalidGateway";
            var payableAmount = 100.0;

            // Act
            var result = _paymentManagerService.ProcessPayment(methodType, payableAmount);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ProcessPayment_NullPaymentGateway_ReturnsFalse()
        {
            // Arrange
            string methodType = null;
            var payableAmount = 100.0;

            // Act
            var result = _paymentManagerService.ProcessPayment(methodType, payableAmount);

            // Assert
            Assert.False(result);
        }
    }
}