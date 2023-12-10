using ParcelLocker.Shared.Abstractions.Exceptions;

namespace ParcelLocker.Shared.Infrastructure.Exceptions;

public interface IExceptionMapperCompositionRoot
{
    ErrorResponse GetExceptionResponse(Exception exception);
}
