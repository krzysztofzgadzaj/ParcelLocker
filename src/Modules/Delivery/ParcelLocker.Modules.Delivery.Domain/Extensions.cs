using Microsoft.Extensions.DependencyInjection;

namespace ParcelLocker.Modules.Delivery.Domain;

public static class Extensions
{
    public static IServiceCollection AddDomain(this IServiceCollection serviceCollection)
        => serviceCollection;
}