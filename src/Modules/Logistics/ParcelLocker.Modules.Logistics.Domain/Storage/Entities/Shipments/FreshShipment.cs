namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Shipments;

public class FreshShipment : Shipment
{
    public override ShipmentType ShipmentType => ShipmentType.FreshFoodShipment;
    public double RecommendedAirHumidity { get; set; }
    public double AcceptableAirHumidityDeviation { get; set; }
    public double RecommendedTemperatureInCelsius { get; set; }
    public double AcceptableTemperatureDeviation { get; set; }
}
