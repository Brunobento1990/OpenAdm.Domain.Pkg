namespace Domain.Pkg.Extensions;

public static class DecimalExtensions
{
    public static string FormatMoney(this decimal value)
    {
        var newValue = value.ToString().Split(".");
        var decimals = newValue[1].Length > 2 ? newValue[1][..2] : newValue[1];
        return $"{newValue[0]},{decimals}";
    }
}
