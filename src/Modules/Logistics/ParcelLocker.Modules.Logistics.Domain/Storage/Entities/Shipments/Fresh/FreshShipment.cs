using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots;
using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots.Fresh;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Shipments.Fresh;

public abstract class FreshShipment : Shipment
{
    public double RecommendedAirHumidity { get; set; }
    public double AcceptableAirHumidityDeviation { get; set; }
    public double RecommendedTemperatureInCelsius { get; set; }
    public double AcceptableTemperatureDeviation { get; set; }

    public abstract bool CanBeStoredToStoringSpot(FreshShipmentStoringSpot storingSpot);

    protected virtual bool IsTemperatureInRange(double temperature)
        => RecommendedTemperatureInCelsius + AcceptableTemperatureDeviation > temperature 
           && RecommendedTemperatureInCelsius - AcceptableTemperatureDeviation < temperature;
    
    protected virtual bool IsAirHumidityInRange(double humidity)
        => RecommendedAirHumidity + AcceptableAirHumidityDeviation > humidity 
           && RecommendedAirHumidity - AcceptableAirHumidityDeviation < humidity;
}
