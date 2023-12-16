using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Shared.Abstractions.Events;

namespace ParcelLocker.Shared.Infrastructure.Modules;

public static class Extensions
{
    public static IServiceCollection AddModuleRegistry(this IServiceCollection serviceCollection, IEnumerable<Assembly> assemblies)
    {
        serviceCollection.AddSingleton<IModuleRegistry>(serviceProvider =>
        {
            var eventDispatcher = serviceProvider.GetService<IEventDispatcher>();
            var eventTypes = assemblies
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IEvent).IsAssignableFrom(x));

            var registry = new ModuleRegistry();

            foreach (var eventType in eventTypes)
            {
                registry.Add(new ModuleRegistryEntry(eventType, x =>
                    (Task) eventDispatcher
                        .GetType()
                        .GetMethod(nameof(eventDispatcher.PublishAsync))
                        ?.MakeGenericMethod(eventType)
                        .Invoke(eventDispatcher, new[] { x })));
            }

            return registry;
        });

        serviceCollection.AddSingleton<IModuleClient, ModuleClient>();

        return serviceCollection;
    }
}
