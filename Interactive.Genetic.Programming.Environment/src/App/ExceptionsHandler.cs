namespace App;

public static class ExceptionsHandler
{
    public static void HandleMainThreadException(object sender, ThreadExceptionEventArgs e)
    {
        var exception = e.Exception;
        var message = exception.Message;

        MessageBox.Show(
            $@"{message}",
            @"Error!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        );
    }
}