using OutPost.Modules.Commission.Application.Events.Internal;
using OutPost.Modules.Commission.Domain.Events;
using OutPost.Shared.Abstractions.Events;
using OutPost.Shared.Abstractions.Kernel.Types;

namespace OutPost.Modules.Commission.Application.Events;

public static class EventMapper
{
    public static IEnumerable<IEvent> Map(IEnumerable<IDomainEvent> domainEvents)
        => domainEvents.Select(x => x.Map());

    public static IEvent Map(this IDomainEvent domainEvent) 
        => domainEvent switch
        {
            CommissionCreatedDomainEvent commissionCreatedDomainEvent => new CommissionCreatedEvent(
                commissionCreatedDomainEvent.CommissionId),
            _ => throw new ApplicationException()
        };
}
