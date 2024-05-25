using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Exceptions;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointDrafts.ParcelLockers;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared;
using OutPost.Modules.Logistics.Domain.Shared;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.ParcelLockers;

public class ParcelLockerSlot
{
    internal ParcelLockerSlot(DraftParcelLockerSlot draftParcelLockerSlot)
    {
        SizeParameters = draftParcelLockerSlot.ParcelLockerSlotSizeParameters;
        Status = ParcelLockerSlotStatus.Available;
    }
    
    public ParcelLockerSlotSizeParameters SizeParameters { get; }
    public ParcelLockerSlotStatus Status { get; private set; }
    public Guid? AssignedParcelId { get; private set; }
    public bool IsReservedOrOccupied => Status is ParcelLockerSlotStatus.Reserved or ParcelLockerSlotStatus.Occupied;

    public bool CanStoreParcel(ParcelParameters parcelParameters)
        => Status == ParcelLockerSlotStatus.Available
           && DoesParcelFits(parcelParameters);

    public void ReserveSlot(Parcel parcel)
    {
        if (!CanStoreParcel(parcel.ParcelParameters))
        {
            throw new CannotAssignParcelToUnavailableSlotException($"Parcel with id: {parcel.Id} cannot be assigned to slot");
        }
        
        AssignedParcelId = parcel.Id;
        Status = ParcelLockerSlotStatus.Reserved;
    }

    public void StoreParcel()
    {
        Status = ParcelLockerSlotStatus.Occupied;
    }
    
    private bool DoesParcelFits(ParcelParameters parcel) 
        => (parcel.LengthInCm <= SizeParameters.LengthInCm && parcel.WidthInCm <= SizeParameters.WidthInCm && parcel.HeightInCm <= SizeParameters.HeightInCm) 
           || (parcel.LengthInCm <= SizeParameters.LengthInCm && parcel.HeightInCm <= SizeParameters.WidthInCm && parcel.WidthInCm <= SizeParameters.HeightInCm) 
           || (parcel.WidthInCm <= SizeParameters.LengthInCm && parcel.LengthInCm <= SizeParameters.WidthInCm && parcel.HeightInCm <= SizeParameters.HeightInCm) 
           || (parcel.WidthInCm <= SizeParameters.LengthInCm && parcel.HeightInCm <= SizeParameters.WidthInCm && parcel.LengthInCm <= SizeParameters.HeightInCm) 
           || (parcel.HeightInCm <= SizeParameters.LengthInCm && parcel.LengthInCm <= SizeParameters.WidthInCm && parcel.WidthInCm <= SizeParameters.HeightInCm) 
           || (parcel.HeightInCm <= SizeParameters.LengthInCm && parcel.WidthInCm <= SizeParameters.WidthInCm && parcel.LengthInCm <= SizeParameters.HeightInCm);
}
