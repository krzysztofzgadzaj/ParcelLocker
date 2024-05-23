using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;

namespace ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.ParcelLocker;

public class ParcelLockerSlot
{
    public ParcelLockerSlot(double lengthInCm, double heightInCm, double widthInCm)
    {
        if (lengthInCm <= 0 || heightInCm <= 0 || widthInCm <= 0)
        {
            throw new IncorrectParcelLockerSlotDimensionException("One of dimensions is incorrect");
        }
        
        LengthInCm = lengthInCm;
        HeightInCm = heightInCm;
        WidthInCm = widthInCm;
        Status = ParcelLockerSlotStatus.Available;
    }
    
    public ParcelLockerSlotStatus Status { get; private set; }
    public double LengthInCm { get; }
    public double WidthInCm { get; }
    public double HeightInCm { get; }
    public ParcelId? AssignedParcelId { get; private set; }
    
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
}
