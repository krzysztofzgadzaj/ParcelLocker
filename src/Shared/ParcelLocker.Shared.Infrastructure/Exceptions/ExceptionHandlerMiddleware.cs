using Microsoft.AspNetCore.Http;

namespace ParcelLocker.Shared.Infrastructure.Exceptions;

public class ExceptionHandlerMiddleware : IMiddleware
{
    private readonly IExceptionMapperCompositionRoot _exceptionMapperCompositionRoot;

    public ExceptionHandlerMiddleware(IExceptionMapperCompositionRoot exceptionMapperCompositionRoot)
    {
        _exceptionMapperCompositionRoot = exceptionMapperCompositionRoot;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleException(exception, context);
        }
    }

    private async Task HandleException(Exception exception, HttpContext httpContext)
    {
        var error = _exceptionMapperCompositionRoot.GetExceptionResponse(exception);
        httpContext.Response.StatusCode = (int) error.StatusCode;
        await httpContext.Response.WriteAsJsonAsync(error);
    }
}
