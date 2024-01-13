namespace Utils;

public static class DateFormatService
{
    public static string ToLongFormat(this DateTime dateTime)
    {
        return dateTime.ToString("dd.MM.yyyy-HH.mm.ss");
    }
}