using Shared;

namespace App;

public static class ExceptionsHandler
{
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