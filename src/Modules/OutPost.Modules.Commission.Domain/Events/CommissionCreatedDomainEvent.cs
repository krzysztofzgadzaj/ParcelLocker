using OutPost.Shared.Abstractions.Kernel.Types;

namespace OutPost.Modules.Commission.Domain.Events;

public record CommissionCreatedDomainEvent(Guid CommissionId) : IDomainEvent;
