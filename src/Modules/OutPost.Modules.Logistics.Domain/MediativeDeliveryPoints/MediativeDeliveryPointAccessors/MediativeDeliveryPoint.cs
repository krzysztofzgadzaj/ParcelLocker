using OutPost.Modules.Logistics.Domain.Shared;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors;

public abstract class MediativeDeliveryPoint : IMdpAvaiability, IMdpStorageAvailability
{
    public  Guid Id { get; init; }
    
    public abstract void Deactivate();
    public abstract bool CanStoreParcel(ParcelParameters parcelParameters);
    public abstract void ReserveSlotForParcel(Parcel parcel);
    public abstract void StoreParcel(Guid parcel);
}
