namespace OutPost.Shared.Abstractions.Exceptions;

public interface IExceptionToResponseMapper
{
    ErrorResponse Map(Exception exception);
}
