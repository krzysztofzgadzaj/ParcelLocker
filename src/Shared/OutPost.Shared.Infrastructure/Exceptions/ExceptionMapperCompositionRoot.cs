using Microsoft.Extensions.DependencyInjection;
using OutPost.Shared.Abstractions.Exceptions;

namespace OutPost.Shared.Infrastructure.Exceptions;

internal class ExceptionMapperCompositionRoot : IExceptionMapperCompositionRoot
{
    private readonly IServiceProvider _serviceProvider;

    public ExceptionMapperCompositionRoot(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ErrorResponse GetExceptionResponse(Exception exception)
    {
        var exceptionToResponseMappers = _serviceProvider.GetServices<IExceptionToResponseMapper>().ToList();
        var notDefaultMappers = exceptionToResponseMappers.Where(x => x is not DefaultExceptionToResponseMapper);
        var notDefaultError = notDefaultMappers
            .Select(x => x.Map(exception))
            .SingleOrDefault(x => x is not null);

        if (notDefaultError is not null)
        {
            return notDefaultError;
        }
        
        var defaultMappers = exceptionToResponseMappers.FirstOrDefault(x => x is DefaultExceptionToResponseMapper);

        return defaultMappers!.Map(exception);
    }
}
