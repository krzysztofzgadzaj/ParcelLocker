using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors;
using OutPost.Shared.Abstractions.Kernel.Types;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointDrafts;

public abstract class MediativeDeliveryPointDraft : AggregateRoot, IMdpDraftAvailability
{
    public abstract MediativeDeliveryPoint Activate();
}
