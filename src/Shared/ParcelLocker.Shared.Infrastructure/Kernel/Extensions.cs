using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Shared.Abstractions.Kernel;

namespace ParcelLocker.Shared.Infrastructure.Kernel;

public static class Extensions
{
    public static IServiceCollection AddDomainEvents(this IServiceCollection serviceCollection, IEnumerable<Assembly> assemblies)
    {
        serviceCollection.AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>();
        serviceCollection.Scan(x
            => x.FromAssemblies(assemblies)
                .AddClasses(y => y.AssignableTo(typeof(IDomainEventHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        
        return serviceCollection;
    }
}
