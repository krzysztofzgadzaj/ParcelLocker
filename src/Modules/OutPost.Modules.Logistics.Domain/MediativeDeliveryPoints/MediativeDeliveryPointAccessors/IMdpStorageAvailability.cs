namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors;

public interface IMdpStorageAvailability
{
    bool CanStoreParcel(ParcelParameters parcelParameters);
    void ReserveSlotForParcel(Parcel parcel);
    void StoreParcel(Parcel parcel);
}
