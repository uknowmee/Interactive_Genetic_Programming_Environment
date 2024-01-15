using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Extensions.Logging;

namespace MyApp.Solver;

public static class LoggingConfiguration
{
    private const string LogsPath = "/logs/console_app/log-.txt";
    public static ILoggerFactory Factory { get; }
    
#if DEBUG
    private static string FullLogsPath => Path.Combine(GoFiveUpFromCurrentDir(), LogsPath);
    private static LoggingLevelSwitch LevelSwitch { get; } = new(LogEventLevel.Verbose);
#else
    private static string FullLogsPath => LogsPath;
    private static LoggingLevelSwitch LevelSwitch { get; } = new(LogEventLevel.Information);
#endif

    static LoggingConfiguration()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .WriteTo.Async(configure => configure
                .File(
                    FullLogsPath,
                    rollingInterval: RollingInterval.Day,
                    levelSwitch: LevelSwitch
                )
            ).WriteTo.Async(configure => configure
                .Console()
            )
            .CreateLogger();


        Factory = new LoggerFactory(new ILoggerProvider[]
            {
                new SerilogLoggerProvider(Log.Logger)
            }
        );
    }
    
    private static string GoFiveUpFromCurrentDir()
    {
        var currentDir = Directory.GetCurrentDirectory();
        var fiveUp = Path.Combine(currentDir, "..", "..", "..", "..", "..");
        return Path.GetFullPath(fiveUp);
    }
}