using System.Net;
using Humanizer;
using ParcelLocker.Shared.Abstractions.Exceptions;
using ParcelLocker.Shared.Abstractions.Exceptions.Types;

namespace ParcelLocker.Shared.Infrastructure.Exceptions;

internal class DefaultExceptionToResponseMapper : IExceptionToResponseMapper
{
    public ErrorResponse Map(Exception exception)
    {
        return exception switch
        {
            NotFoundException notFoundException => new ErrorResponse(HttpStatusCode.NotFound, new Error(GetErrorCode(exception), notFoundException.Message)),
            DomainException domainException => new ErrorResponse(HttpStatusCode.UnprocessableEntity, new Error(GetErrorCode(exception), domainException.Message)),
            CoreException coreException => new ErrorResponse(HttpStatusCode.BadRequest, new Error(GetErrorCode(exception), coreException.Message)),
            _ => new ErrorResponse(HttpStatusCode.InternalServerError, new Error(GetErrorCode(exception), "Internal error"))
        };
    }
    
    private record Error(string StatusCode, string Description);
    
    private static string GetErrorCode(object exception)
    {
        var type = exception.GetType();
        return type.Name.Underscore().Replace("_exception", string.Empty);
    }
}
