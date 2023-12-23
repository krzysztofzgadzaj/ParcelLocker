using Microsoft.Extensions.DependencyInjection;

namespace ParcelLocker.Modules.Delivery.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        => serviceCollection;
}