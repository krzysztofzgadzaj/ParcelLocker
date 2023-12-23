using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Shared.Abstractions.Kernel;

public interface IDomainEventHandler<in TEvent> where TEvent : class, IDomainEvent
{
    Task HandleAsync(TEvent domainEvent);
}
