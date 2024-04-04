namespace Domain.Pkg.Extensions;

public static class DecimalExtensions
{
    public static string FormatMoney(this decimal value)
    {
        var newValue = value.ToString().Split(".");
        if (newValue?.Length > 0)
        {
            var numero = newValue.ElementAtOrDefault(0)?.Length > 0 ? newValue.ElementAtOrDefault(0) : "0";
            var decimals = newValue.ElementAtOrDefault(1);
            if (!string.IsNullOrWhiteSpace(decimals))
            {
                decimals = decimals.Length > 2 ? decimals[..1] : $"{decimals}0";
            }
            else
            {
                decimals = "00";
            }

            return $"{numero},{decimals}";
        }
        else
        {
            return "0,00";
        }        
    }
}
