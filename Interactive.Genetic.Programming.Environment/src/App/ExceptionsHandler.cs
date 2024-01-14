using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Shared;

namespace App;

public class ExceptionsHandler
{
    public static ILogger<ExceptionsHandler> Logger { get; set; } = new NullLogger<ExceptionsHandler>();

    public static void HandleMainThreadException(object sender, ThreadExceptionEventArgs e)
    {
        var exception = e.Exception;

        switch (exception)
        {
            case CustomException:
                HandleCustomException(exception);
                break;
            default:
                HandleException(exception);
                break;
        }
    }

    private static void HandleCustomException(Exception exception)
    {
        var message = exception.Message;
        Logger.LogError(exception, "Custom exception occurred!");

        MessageBox.Show(
            $@"{message}",
            @"Error!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        );
    }

    private static void HandleException(Exception exception)
    {
        var message = exception.Message;
        Logger.LogError(exception, "Exception occurred!");

#if DEBUG
        MessageBox.Show(
            $@"{message}",
            @"Error DEV!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        );
#endif
    }
}