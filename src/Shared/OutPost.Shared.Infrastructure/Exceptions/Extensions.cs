using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OutPost.Shared.Abstractions.Exceptions;

namespace OutPost.Shared.Infrastructure.Exceptions;

internal static class Extensions
{
    public static IServiceCollection AddExceptionHandling(this IServiceCollection serviceCollection)
        => serviceCollection
            .AddScoped<ExceptionHandlerMiddleware>()
            .AddSingleton<IExceptionToResponseMapper, DefaultExceptionToResponseMapper>()
            .AddSingleton<IExceptionMapperCompositionRoot, ExceptionMapperCompositionRoot>();

    public static WebApplication UseExceptionHandling(this WebApplication webApplication)
    {
        webApplication.UseMiddleware<ExceptionHandlerMiddleware>();

        return webApplication;
    }
}
