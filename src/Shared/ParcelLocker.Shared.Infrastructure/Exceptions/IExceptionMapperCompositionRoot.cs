using ParcelLocker.Shared.Abstractions.Exceptions;

namespace ParcelLocker.Shared.Infrastructure.Exceptions;

internal interface IExceptionMapperCompositionRoot
{
    ErrorResponse GetExceptionResponse(Exception exception);
}
