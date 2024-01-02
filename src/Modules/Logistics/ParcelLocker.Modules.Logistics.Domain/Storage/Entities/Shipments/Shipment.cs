using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Shipments;

public class Shipment : AggregateRoot
{
    public ShipmentType ShipmentType { get; }
    public string FactoryName { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
    public double Volume => Width * Height * Length;
    public double Weight { get; set; }
    public double RecommendedAirHumidity { get; set; }
    public double AcceptableAirHumidityDeviation { get; set; }
    public double RecommendedTemperatureInCelsius { get; set; }
    public double AcceptableTemperatureDeviation { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool IsBreakable { get; set; }
    public bool IsPriority { get; set; }

    public bool TemperatureInRange(double temperature)
    {
        return RecommendedTemperatureInCelsius + AcceptableTemperatureDeviation > temperature
               && RecommendedTemperatureInCelsius - AcceptableTemperatureDeviation < temperature;
    }
    
    public bool HumidityInRange(double temperature)
    {
        return RecommendedAirHumidity + AcceptableAirHumidityDeviation > temperature
               && RecommendedAirHumidity - AcceptableAirHumidityDeviation < temperature;
    }
}
