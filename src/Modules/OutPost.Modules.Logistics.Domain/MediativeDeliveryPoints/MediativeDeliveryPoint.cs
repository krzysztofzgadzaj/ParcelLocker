using OutPost.Shared.Abstractions.Kernel.Types;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints;

public abstract class MediativeDeliveryPoint : AggregateRoot, IMdpAvaiability, IMdpStorageAvailability
{
    public abstract void Activate();
    public abstract void Deactivate();
    public abstract bool CanStoreParcel(ParcelParameters parcelParameters);
    public abstract void ReserveSlotForParcel(Parcel parcel);
    public abstract void StoreParcel(Parcel parcel);
}
