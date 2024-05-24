namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.DTO;

public class ParcelLockerSlotDto
{
    public ParcelLockerSlotDto()
    {
    }
    
    public ParcelLockerSlotDto(double lengthInCm, double widthInCm, double heightInCm)
    {
        LengthInCm = lengthInCm;
        WidthInCm = widthInCm;
        HeightInCm = heightInCm;
    }

    public double LengthInCm { get; set; } 
    public double WidthInCm { get; set; }
    public double HeightInCm { get; set; }
}
