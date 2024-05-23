using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Modules.Commission.Application.BackgroundProcessing;

namespace ParcelLocker.Modules.Commission.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHostedService<OutpostConfigurationBackgroundService>();

        return serviceCollection;
    }
}
