using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Exceptions;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointDrafts.ShoppingPoints;

public class StorageCapacity
{
    private const int _minimumCapacityInCm = 10 * 100 * 100 * 100;
    
    public StorageCapacity(double maxParcelLengthInCm, double maxParcelHeightInCm, double maxParcelWidthInCm, double maxParcelWeightInKg, double capacityInCm)
    {
        if (maxParcelLengthInCm < 64 || maxParcelHeightInCm <= 41 || maxParcelWidthInCm <= 38)
        {
            throw new IncorrectParcelLockerSlotDimensionException("One of dimensions is incorrect");
        }

        MaxParcelLengthInCm = maxParcelLengthInCm;
        MaxParcelHeightInCm = maxParcelHeightInCm;
        MaxParcelWidthInCm = maxParcelWidthInCm;
        
        if (maxParcelWeightInKg < 25)
        {
            throw new ApplicationException();
        }
        
        MaxParcelWeightInKg = maxParcelWeightInKg;

        if (capacityInCm < _minimumCapacityInCm)
        {
            throw new ArgumentException();
        }
        
        CapacityInCm = capacityInCm;
    }
    
    public double MaxParcelLengthInCm { get; }
    public double MaxParcelWidthInCm { get; }
    public double MaxParcelHeightInCm { get; }
    public double MaxParcelWeightInKg { get; }
    public double CapacityInCm { get; }
}
