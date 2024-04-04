namespace Domain.Pkg.Extensions;

public static class DecimalExtensions
{
    public static string FormatMoney(this decimal value)
    {
        var newValue = value.ToString().Split(".");
        if (newValue?.Length > 0)
        {
            var numero = newValue[0]?.Length > 0 ? newValue[0] : "0";
            string? decimals;
            if (newValue[1]?.Length > 0)
            {
                decimals = newValue[1]?.Length > 2 ? newValue[1]?[..2] : $"{newValue[1]}0";
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
