using Domain.Pkg.Errors;

namespace Domain.Pkg.Exceptions;

public class ExceptionApi(string? message = CodigoErrors.ErrorGeneric) 
    : Exception(message)
{
}
