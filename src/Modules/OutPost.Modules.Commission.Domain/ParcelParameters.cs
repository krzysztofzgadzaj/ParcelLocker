namespace OutPost.Modules.Commission.Domain;

public class ParcelParameters
{
    public ParcelParameters(double heightInCm, double widthInCm, double lengthInCm, double weightInGrams)
    {
        if (lengthInCm <= 0 || widthInCm <= 0 || heightInCm <= 0 || weightInGrams <= 0)
        {
            throw new ApplicationException("One of dimensions is incorrect");
        }
        
        HeightInCm = heightInCm;
        WidthInCm = widthInCm;
        LengthInCm = lengthInCm;
        WeightInGrams = weightInGrams;
    }

    public double LengthInCm { get; }
    public double WidthInCm { get; }
    public double HeightInCm { get; }
    public double WeightInGrams { get; }
}
