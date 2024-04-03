namespace Domain.Pkg.Extensions;

public static class DecimalExtensions
{
    public static string FormatMoney(this decimal value)
    {
        return value.ToString().Replace(".", ",");
    }
}
