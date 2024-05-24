using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Exceptions;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared;

public class ParcelLockerSlotSizeParameters
{
    public ParcelLockerSlotSizeParameters(double lengthInCm, double widthInCm, double heightInCm)
    {
        if (lengthInCm <= 0 || widthInCm <= 0 || heightInCm <= 0)
        {
            throw new IncorrectParcelLockerSlotDimensionException("One of dimensions is incorrect");
        }
        
        LengthInCm = lengthInCm;
        WidthInCm = widthInCm;
        HeightInCm = heightInCm;
    }
    
    public double LengthInCm { get; }
    public double WidthInCm { get; }
    public double HeightInCm { get; }
}
