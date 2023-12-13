using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Modules.Storage.Core.Repositories;
using ParcelLocker.Modules.Storage.Core.Services;

namespace ParcelLocker.Modules.Storage.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
        => serviceCollection
            .AddScoped<IStorageService, StorageService>()
            .AddSingleton<IStorageRepository, StorageRepository>();
}