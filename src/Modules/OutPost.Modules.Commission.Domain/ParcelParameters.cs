namespace OutPost.Modules.Commission.Domain;

public class ParcelParameters
{
    public ParcelParameters(double lengthInCm, double widthInCm, double heightInCm, double weightInKg)
    {
        if (lengthInCm <= 0 || lengthInCm > 100 || heightInCm <= 0 || heightInCm > 100 || widthInCm < 0 || widthInCm > 100 || weightInKg > 100)
        {
            throw new ArgumentException();
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
