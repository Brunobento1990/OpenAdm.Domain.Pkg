using Domain.Pkg.Errors;
using Domain.Pkg.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.Pkg.Validations;

public static class ValidationEmail
{
    public static void ValidWithLength(string? email, int length = 255)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ExceptionApi(CodigoErrors.ErrorEmailInvalido);

        if (!Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
        {
            throw new ExceptionApi(CodigoErrors.ErrorEmailInvalido);
        }
    }
}
