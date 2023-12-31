using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Shipments;
using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots;

public abstract class StoringSpot : AggregateRoot
{
    protected List<Shipment> Shipments { get; set; }
 
    public abstract StoringSpotType StoringSpotType { get; }
    public abstract bool HasPlaceForShipment(Shipment shipment);
    public abstract void AddShipment(Shipment shipment);
    public abstract void AddShipments(IEnumerable<Shipment> shipments);
    
    // TODO - Verify if you shouldn't wrap aggregateId
    public abstract void RemoveShipment(AggregateId shipmentId);
    public abstract void RemoveShipments(IEnumerable<AggregateId> shipmentIds);
}
