using Moq;
using Billing.Services.PaymentGateway;

namespace Billing.UnitTests
{
    public class PaymentGatewayTests
    {

        [Fact]
        public void PayPalGateway_ProcessPayment_ValidAmount_ReturnsTrue()
        {
            // Arrange
            var payPalGateway = new PayPalGateway();
            double? payableAmount = 100.0;

            // Act
            var result = payPalGateway.ProcessPayment(payableAmount);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void PayPalGateway_ProcessPayment_InvalidAmount_ReturnsFalse()
        {
            // Arrange
            var payPalGateway = new PayPalGateway();
            double? payableAmount = -100.0;

            // Act
            var result = payPalGateway.ProcessPayment(payableAmount);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void SwedBankGateway_ProcessPayment_ValidAmount_ReturnsTrue()
        {
            // Arrange
            var swedBankGateway = new SwedBankGateway();
            double? payableAmount = 100.0;

            // Act
            var result = swedBankGateway.ProcessPayment(payableAmount);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void SwedBankGateway_ProcessPayment_InvalidAmount_ReturnsFalse()
        {
            // Arrange
            var swedBankGateway = new SwedBankGateway();
            double? payableAmount = -100.0;

            // Act
            var result = swedBankGateway.ProcessPayment(payableAmount);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void SebGateway_ProcessPayment_ValidAmount_ReturnsTrue()
        {
            // Arrange
            var sebGateway = new SebGateway();
            double? payableAmount = 100.0;

            // Act
            var result = sebGateway.ProcessPayment(payableAmount);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void SebGateway_ProcessPayment_InvalidAmount_ReturnsFalse()
        {
            // Arrange
            var sebGateway = new SebGateway();
            double? payableAmount = -100.0;

            // Act
            var result = sebGateway.ProcessPayment(payableAmount);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void PayPalGateway_GetPaymentMethodType_ReturnsPayPal()
        {
            // Arrange
            var payPalGateway = new PayPalGateway();

            // Act
            var result = payPalGateway.GetPaymentMethodType();

            // Assert
            Assert.Equal("PayPal", result);
        }

        [Fact]
        public void SwedBankGateway_GetPaymentMethodType_ReturnsSwedBank()
        {
            // Arrange
            var swedBankGateway = new SwedBankGateway();

            // Act
            var result = swedBankGateway.GetPaymentMethodType();

            // Assert
            Assert.Equal("SwedBank", result);
        }

        [Fact]
        public void SebGateway_GetPaymentMethodType_ReturnsSEB()
        {
            // Arrange
            var sebGateway = new SebGateway();

            // Act
            var result = sebGateway.GetPaymentMethodType();

            // Assert
            Assert.Equal("SEB", result);
        }
    }
}