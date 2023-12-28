using Microsoft.Extensions.DependencyInjection;

namespace ParcelLocker.Modules.Logistics.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        => serviceCollection;
}