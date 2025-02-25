using Serilog;

namespace Billing.Services;

public static class AppExtension
{
    public static void SerilLogConfiguration (this IHostBuilder host)
    {
        host.UseSerilog((context, loggerConfig) =>
        {
            loggerConfig.WriteTo.Console();
        });
    }
}

