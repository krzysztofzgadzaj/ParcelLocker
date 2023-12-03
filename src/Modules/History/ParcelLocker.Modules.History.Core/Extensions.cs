using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Modules.History.Core.Repositories;
using ParcelLocker.Modules.History.Core.Services;

namespace ParcelLocker.Modules.History.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
        => serviceCollection
            .AddScoped<IHistoryService, HistoryService>()
            .AddScoped<IHistoryRepository, HistoryRepository>();
}
