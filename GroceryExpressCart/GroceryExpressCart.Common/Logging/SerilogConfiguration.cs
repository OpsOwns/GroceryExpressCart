using GroceryExpressCart.Common.Extension;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;

namespace GroceryExpressCart.Common.Loging
{
    public static class SerilogConfiguration
    {
        public static IHostBuilder UseLoging(this IHostBuilder webHostBuilder, string applicationName = null) =>
            webHostBuilder.UseSerilog((context, loggerConfiguration) =>
            {
                var serilogOptions = context.Configuration.GetOptions<SerilogModel>("serilog");
                if (!Enum.TryParse<LogEventLevel>(serilogOptions.Level, true, out var level))
                    level = LogEventLevel.Information;
                loggerConfiguration.Enrich.FromLogContext()
                    .MinimumLevel.Is(level)
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .Enrich.WithProperty("ApplicationName", applicationName);
                Configure(loggerConfiguration, serilogOptions);
            });
        private static void Configure(LoggerConfiguration loggerConfiguration, SerilogModel serilogOptions)
        {
            if (serilogOptions.ConsoleEnabled)
                loggerConfiguration.WriteTo.Console();
            loggerConfiguration.WriteTo.File($"Logs\\log-{DateTime.Now.ToStringDate()}.txt", LogEventLevel.Information, "[{Timestamp:HH:mm} {Level:u3}] {Message:lj}{NewLine}{Exception}");
        }
    }
}
