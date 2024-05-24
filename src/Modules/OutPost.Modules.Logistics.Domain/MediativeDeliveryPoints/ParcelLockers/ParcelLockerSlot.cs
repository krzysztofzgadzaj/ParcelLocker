using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.ParcelLockers;

public class ParcelLockerSlot
{
    public ParcelLockerSlot(double lengthInCm, double widthInCm, double heightInCm)
    {
        if (lengthInCm <= 0 || widthInCm <= 0 || heightInCm <= 0)
        {
            throw new IncorrectParcelLockerSlotDimensionException("One of dimensions is incorrect");
        }
        
        LengthInCm = lengthInCm;
        WidthInCm = widthInCm;
        HeightInCm = heightInCm;
        Status = ParcelLockerSlotStatus.Available;
    }
    
    public ParcelLockerSlotStatus Status { get; private set; }
    public double LengthInCm { get; }
    public double WidthInCm { get; }
    public double HeightInCm { get; }
    public Guid? AssignedParcelId { get; private set; }
    
    public bool IsReservedOrOccupied => Status is ParcelLockerSlotStatus.Reserved or ParcelLockerSlotStatus.Occupied;
    
    public bool HasStandardSmallDimensions
        => LengthInCm == 8
           && WidthInCm == 38
           && HeightInCm == 64;
    
    public bool HasStandardMediumDimensions
        => LengthInCm == 19
           && WidthInCm == 38
           && HeightInCm == 64;
    
    public bool HasStandardBigDimensions
        => LengthInCm == 41
           && WidthInCm == 28
           && HeightInCm == 64;

    public bool CanStoreParcel(ParcelParameters parcelParameters)
        => Status == ParcelLockerSlotStatus.Available
           && DoesParcelFits(parcelParameters);

    public void ReserveSlot(Parcel parcel)
    {
        if (!CanStoreParcel(parcel.ParcelParameters))
        {
            throw new ApplicationException();
        }
        
        AssignedParcelId = parcel.Id;
        Status = ParcelLockerSlotStatus.Reserved;
    }

    public void StoreParcel(Parcel parcel)
    {
        if (parcel.Id != AssignedParcelId)
        {
            throw new ApplicationException();
        }

        Status = ParcelLockerSlotStatus.Occupied;
    }
    
    private bool DoesParcelFits(ParcelParameters parcel)
    {
        return (parcel.LengthInCm <= LengthInCm  && parcel.WidthInCm <= WidthInCm && parcel.HeightInCm <= HeightInCm) ||
               (parcel.LengthInCm <= LengthInCm  && parcel.HeightInCm <= WidthInCm && parcel.WidthInCm <= HeightInCm) ||
               (parcel.WidthInCm <= LengthInCm && parcel.LengthInCm <= WidthInCm && parcel.HeightInCm <= HeightInCm) ||
               (parcel.WidthInCm <= LengthInCm && parcel.HeightInCm <= WidthInCm && parcel.LengthInCm <= HeightInCm) ||
               (parcel.HeightInCm <= LengthInCm  && parcel.LengthInCm <= WidthInCm && parcel.WidthInCm <= HeightInCm) ||
               (parcel.HeightInCm <= LengthInCm  && parcel.WidthInCm <= WidthInCm && parcel.LengthInCm <= HeightInCm);
    }
}
