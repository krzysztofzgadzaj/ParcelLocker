using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Modules.History.Core;

namespace ParcelLocker.Modules.History.Api;

internal static class Extensions
{
    public static IServiceCollection AddHistory(this IServiceCollection serviceCollection)
        => serviceCollection
            .AddCore();
}
