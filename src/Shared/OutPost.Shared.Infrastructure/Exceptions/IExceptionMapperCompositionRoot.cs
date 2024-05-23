using OutPost.Shared.Abstractions.Exceptions;

namespace OutPost.Shared.Infrastructure.Exceptions;

internal interface IExceptionMapperCompositionRoot
{
    ErrorResponse GetExceptionResponse(Exception exception);
}
