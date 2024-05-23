using OutPost.Shared.Abstractions.Kernel.Types;

namespace OutPost.Shared.Abstractions.Kernel;

public interface IDomainEventDispatcher
{
    Task PublishAsync(IDomainEvent[] domainEvents);
}
