using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots;
using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots.Fresh;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Shipments.Fresh;

public class DiaryShipment : FreshShipment
{
    public override ShipmentType ShipmentType => ShipmentType.FreshFoodShipment;

    public override bool CanBeStoredToStoringSpot(FreshShipmentStoringSpot storingSpot)
        => IsTemperatureInRange(storingSpot.Temperature);
}
