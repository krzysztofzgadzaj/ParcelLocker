using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointDrafts.ParcelLockers;

public class DraftParcelLockerSlot
{
    public DraftParcelLockerSlot(ParcelLockerSlotSizeParameters parcelLockerSlotSizeParameters)
    {
        ParcelLockerSlotSizeParameters = parcelLockerSlotSizeParameters;
    }

    public ParcelLockerSlotSizeParameters ParcelLockerSlotSizeParameters { get; init; }
}
