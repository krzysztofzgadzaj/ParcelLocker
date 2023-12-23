using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Shared.Abstractions.Kernel;

public interface IDomainEventDispatcher
{
    Task PublishAsync(IDomainEvent[] domainEvents);
}
