using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Shared.Abstractions.Commands;

namespace ParcelLocker.Shared.Infrastructure.Commands;

public static class Extensions
{
    public static IServiceCollection AddCommands(this IServiceCollection serviceCollection, IEnumerable<Assembly> assemblies)
    {
        serviceCollection.AddSingleton<ICommandDispatcher, CommandDispatcher>();
        serviceCollection.Scan(x
            => x.FromAssemblies(assemblies)
                .AddClasses(y => y.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        
        return serviceCollection;
    }
}
