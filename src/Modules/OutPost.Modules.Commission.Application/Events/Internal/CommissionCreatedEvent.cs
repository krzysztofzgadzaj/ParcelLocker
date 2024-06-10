using OutPost.Shared.Abstractions.Events;
using OutPost.Shared.Abstractions.Events;

namespace OutPost.Modules.Commission.Application.Events.Internal;

public record CommissionCreatedEvent(Guid CommissionId) : IEvent;
