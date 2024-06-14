using OutPost.Shared.Abstractions.Events;

namespace OutPost.Modules.Commission.Application.Events.Internal;

public record CommissionFulfilledEvent(Guid CommissionId) : IEvent;
