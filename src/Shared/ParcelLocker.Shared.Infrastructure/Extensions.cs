using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Shared.Infrastructure.Api;

namespace ParcelLocker.Shared.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddControllers()
            .ConfigureApplicationPartManager(manager => 
                manager
                    .FeatureProviders
                    .Add(new InternalControllerFeatureProvider()));

        return serviceCollection;
    }

    public static WebApplication UseInfrastructure(this WebApplication webApplication)
    {
        webApplication.MapControllers();

        return webApplication;
    }
}
