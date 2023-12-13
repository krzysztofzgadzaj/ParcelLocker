using ParcelLocker.Shared.Abstractions.Events;

namespace ParcelLocker.Shared.Infrastructure.Events;

public interface IEventDispatcher
{
    Task PublishAsync<TEvent>(TEvent @event) where TEvent : class, IEvent;
}