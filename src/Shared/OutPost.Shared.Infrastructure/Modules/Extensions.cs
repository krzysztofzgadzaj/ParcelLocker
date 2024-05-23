using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OutPost.Shared.Abstractions.Events;
using OutPost.Shared.Infrastructure.Modules.ModuleRegistry;
using Registry = OutPost.Shared.Infrastructure.Modules.ModuleRegistry.ModuleRegistry;

namespace OutPost.Shared.Infrastructure.Modules;

public static class Extensions
{
    public static IServiceCollection AddModuleRegistry(this IServiceCollection serviceCollection, IEnumerable<Assembly> assemblies)
    {
        serviceCollection.AddSingleton<IModuleRegistry>(serviceProvider =>
        {
            var registry = new ModuleRegistry.ModuleRegistry();

            return registry.PopulateAsyncOperations(serviceProvider, assemblies);
        });

        serviceCollection.AddSingleton<IModuleClient, ModuleClient>();
        serviceCollection.AddSingleton<IRequestRegistry, RequestRegistry>();

        return serviceCollection;
    }

    public static IRequestRegistry UseRequestRegistration(this WebApplication webApplication)
        => webApplication.Services.GetRequiredService<IRequestRegistry>();

    private static ModuleRegistry.ModuleRegistry PopulateAsyncOperations(this ModuleRegistry.ModuleRegistry moduleRegistry, IServiceProvider serviceProvider, IEnumerable<Assembly> assemblies)
    {
        var eventDispatcher = serviceProvider.GetService<IEventDispatcher>();
        var eventTypes = assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(IEvent).IsAssignableFrom(x));
        
        foreach (var eventType in eventTypes)
        {
            moduleRegistry.AddBroadcastNotification(new BroadcastNotificationRegistryEntry(eventType, x =>
                (Task) eventDispatcher
                    .GetType()
                    .GetMethod(nameof(eventDispatcher.PublishAsync))
                    ?.MakeGenericMethod(eventType)
                    .Invoke(eventDispatcher, new[] { x })));
        }

        return moduleRegistry;
    }
}
