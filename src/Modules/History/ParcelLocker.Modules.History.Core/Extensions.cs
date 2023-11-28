using Microsoft.Extensions.DependencyInjection;

namespace ParcelLocker.Modules.History.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
        => serviceCollection;
}
