using Billing.Services.BillingService;
using Billing.Services.PaymentGateway;
using Billing.Services.ReciptService;
using Billing.Services;
using Billing.Services.DateTimeProvider;

namespace Billing.Configuration
{    public static class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBillingService, BillingService>();
            services.AddScoped<IReceiptService, ReceiptService>();
            services.AddScoped<IPaymentGateway, PayPalGateway>();
            services.AddScoped<IPaymentGateway, SwedBankGateway>();
            services.AddScoped<IPaymentGateway, SebGateway>();
            services.AddScoped<IPaymentManagerService, PaymentManagerService>();
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        }
    }
}
