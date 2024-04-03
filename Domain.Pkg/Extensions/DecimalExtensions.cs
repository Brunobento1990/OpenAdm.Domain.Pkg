namespace Domain.Pkg.Extensions;

public static class DecimalExtensions
{
    public static string FormatMoney(this decimal value)
    {
        var newValue = value.ToString();
        return newValue.Replace(".", ",")[..(newValue.Length - 2)];
    }
}
