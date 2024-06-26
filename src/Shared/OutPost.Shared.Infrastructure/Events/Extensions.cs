﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using OutPost.Shared.Abstractions.Events;

namespace OutPost.Shared.Infrastructure.Events;

internal static class Extensions
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
