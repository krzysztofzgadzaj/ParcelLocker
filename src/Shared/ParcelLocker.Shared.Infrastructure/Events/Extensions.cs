using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Shared.Abstractions.Events;

namespace ParcelLocker.Shared.Infrastructure.Events;

public static class Extensions
{
    public static IServiceCollection AddEvents(this IServiceCollection serviceCollection, IEnumerable<Assembly> assemblies)
    {
        serviceCollection.AddSingleton<IEventDispatcher, EventDispatcher>();
        serviceCollection.Scan(x
            => x.FromAssemblies(assemblies)
                .AddClasses(y => y.AssignableTo(typeof(IEventHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        
        return serviceCollection;
    }
}
