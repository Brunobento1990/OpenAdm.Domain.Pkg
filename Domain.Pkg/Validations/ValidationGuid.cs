using Domain.Pkg.Errors;
using Domain.Pkg.Exceptions;

namespace Domain.Pkg.Validations;

public static class ValidationGuid
{
    public static void ValidGuidNullAndEmpty(Guid? guid, string message = CodigoErrors.ErrorGeneric)
    {
        if (guid == null || guid.Value == Guid.Empty)
        {
            throw new ExceptionApi(message);
        }
    }
}
