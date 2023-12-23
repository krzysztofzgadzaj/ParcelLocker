using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Shared.Abstractions.Kernel;
using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Shared.Infrastructure.Kernel;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task PublishAsync(IDomainEvent[] domainEvents)
    {
        using var scope = _serviceProvider.CreateScope();

        foreach (var domainEvent in domainEvents)
        {
            var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
            var handlers = scope.ServiceProvider.GetServices(handlerType);

            var handleTasks = handlers.Select(x => (Task) handlerType
                .GetMethod(nameof(IDomainEventHandler<IDomainEvent>.HandleAsync))
                ?.Invoke(x, new[] {domainEvent}));

            await Task.WhenAll(handleTasks);
        }
    }
}
