using OutPost.Shared.Abstractions.Kernel.Types;

namespace OutPost.Shared.Abstractions.Kernel;

public interface IDomainEventHandler<in TEvent> where TEvent : class, IDomainEvent
{
    Task HandleAsync(TEvent domainEvent);
}
