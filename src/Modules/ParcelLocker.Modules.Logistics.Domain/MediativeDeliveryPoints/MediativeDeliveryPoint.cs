using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints;

public abstract class MediativeDeliveryPoint : AggregateRoot<MediativeDeliveryPointId>, IMdpAvaiability
{
    public abstract void Activate();
    public abstract void Deactivate();
}
