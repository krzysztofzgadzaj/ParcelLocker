using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots.Standard;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Shipments.Standard;

public abstract class StandardShipment : Shipment
{
    public bool IsBreakable { get; set; }
    public bool IsPriority { get; set; }
    public double Weight { get; set; }
    
    public abstract bool CanBeStoredToStoringSpot(StandardStoringSpot storingSpot);
}
