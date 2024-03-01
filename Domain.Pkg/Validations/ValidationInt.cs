using Domain.Pkg.Errors;
using Domain.Pkg.Exceptions;

namespace Domain.Pkg.Validations;

public static class ValidationInt
{
    public static void ValidateIntNullAndZero(int? value, string message = CodigoErrors.ErrorGeneric)
    {
        if (value == null || value == 0)
        {
            throw new ExceptionApi(message);
        }
    }
}
