using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Shared.Abstractions.Events;
using ParcelLocker.Shared.Infrastructure.Modules.ModuleRegistry;
using Registry = ParcelLocker.Shared.Infrastructure.Modules.ModuleRegistry.ModuleRegistry;

namespace ParcelLocker.Shared.Infrastructure.Modules;

public static class Extensions
{
    public static IServiceCollection AddModuleRegistry(this IServiceCollection serviceCollection, IEnumerable<Assembly> assemblies)
    {
        serviceCollection.AddSingleton<IModuleRegistry>(serviceProvider =>
        {
            var registry = new Registry();

            return registry.PopulateAsyncOperations(serviceProvider, assemblies);
        });

        serviceCollection.AddSingleton<IModuleClient, ModuleClient>();
        serviceCollection.AddSingleton<IModuleDisplayer, ModuleDisplayer>();

        return serviceCollection;
    }

    public static IModuleDisplayer UseSyncCommunication(this WebApplication webApplication)
        => webApplication.Services.GetRequiredService<IModuleDisplayer>();

    private static Registry PopulateAsyncOperations(this Registry moduleRegistry, IServiceProvider serviceProvider, IEnumerable<Assembly> assemblies)
    {
        var eventDispatcher = serviceProvider.GetService<IEventDispatcher>();
        var eventTypes = assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(IEvent).IsAssignableFrom(x));
        
        foreach (var eventType in eventTypes)
        {
            moduleRegistry.AddAsyncCommunication(new ModuleRegistryEntry(eventType, x =>
                (Task) eventDispatcher
                    .GetType()
                    .GetMethod(nameof(eventDispatcher.PublishAsync))
                    ?.MakeGenericMethod(eventType)
                    .Invoke(eventDispatcher, new[] { x })));
        }

        return moduleRegistry;
    }
}
