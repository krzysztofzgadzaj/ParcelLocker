using ParcelLocker.Shared.Abstractions.Events;

namespace ParcelLocker.Shared.Infrastructure.Modules;

public interface IModuleClient
{
    public Task PublishAsync<TEvent>(TEvent @event) where TEvent : class, IEvent;
}
