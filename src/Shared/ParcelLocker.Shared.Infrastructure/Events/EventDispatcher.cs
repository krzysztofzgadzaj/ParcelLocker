using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Shared.Abstractions.Events;

namespace ParcelLocker.Shared.Infrastructure.Events;

internal class EventDispatcher : IEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public EventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : class, IEvent
    {
        using var scope = _serviceProvider.CreateScope();
        var eventHandlers = scope.ServiceProvider.GetServices<IEventHandler<TEvent>>();
        var handleEventTasks = eventHandlers.Select(x => x.HandleAsync(@event));
        await Task.WhenAll(handleEventTasks);
    }
}
