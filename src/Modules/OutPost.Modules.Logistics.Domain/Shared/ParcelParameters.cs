using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Exceptions;

namespace OutPost.Modules.Logistics.Domain.Shared;

public class ParcelParameters
{
    public ParcelParameters(double lengthInCm, double widthInCm, double heightInCm, double weightInKg)
    {
        if (lengthInCm < 0 || heightInCm < 0 || widthInCm < 0)
        {
            throw new IncorrectParcelParametersException("One of dimensions is incorrect");
        }
        
        LengthInCm = lengthInCm;
        WidthInCm = widthInCm;
        HeightInCm = heightInCm;
        WeightInKg = weightInKg;
    }
    
    public double LengthInCm { get; init; } 
    public double WidthInCm { get; init; }
    public double HeightInCm { get; init; }
    public double WeightInKg { get; init; }
}
