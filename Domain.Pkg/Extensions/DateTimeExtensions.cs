namespace Domain.Pkg.Extensions;

public static class DateTimeExtensions
{
    public static string DateTimeToString(this DateTime dateTime)
    {
        return dateTime.ToString("dd/MM/yyyy");
    }
}
