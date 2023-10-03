using Serilog.Core;
using Serilog.Events;

namespace StudentToolkit.Configuration.DI;

public static class RegisterLoggerExtention
{
    private const string OutputTemplate 
        = "{Timestamp:[dd-MM-yyyy] [HH:mm:ss]} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

    public static Container RegisterLogger(this Container container)
    {
        var minLogLevel = LogEventLevel.Information;

#if DEBUG
        minLogLevel = LogEventLevel.Debug;
#endif
        Logger logger = new LoggerConfiguration()
            .MinimumLevel.Is(minLogLevel)
            .WriteTo.File(
                path: "Logs/log-.txt",
                outputTemplate: OutputTemplate,
                rollingInterval: RollingInterval.Day,
                shared: true)
            .CreateLogger();

        container.RegisterSingleton<ILogger>(() => logger);

        return container;
    }
}
