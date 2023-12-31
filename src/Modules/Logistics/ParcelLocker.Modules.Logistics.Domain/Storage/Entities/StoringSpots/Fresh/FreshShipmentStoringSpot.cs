namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots.Fresh;

public abstract class FreshShipmentStoringSpot : StoringSpot
{
    public double Height { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
    public double Volume => Width * Height * Length;
    public double Temperature { get; set; }
    public double AirHumidity { get; set; }
}
