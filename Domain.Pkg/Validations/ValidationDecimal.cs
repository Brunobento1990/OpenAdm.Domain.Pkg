using Domain.Pkg.Errors;
using Domain.Pkg.Exceptions;

namespace Domain.Pkg.Validations;

public class ValidationDecimal
{
    public static void ValidDecimalNullAndZero(decimal? value, string message = CodigoErrors.ErrorGeneric)
    {
        if (value == null || value.Value <= 0)
        {
            throw new ExceptionApi(message);
        }
    }
}
