using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Shipments;
using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots.Standard;

public abstract class StandardStoringSpot : StoringSpot
{
    public abstract bool HasPlaceForShipment(StandardShipment shipment);
    public abstract void AddShipment(StandardShipment shipment);
    public abstract void AddShipments(IEnumerable<StandardShipment> shipments);
    public abstract void RemoveShipment(AggregateId shipmentId);
    public abstract void RemoveShipments(IEnumerable<AggregateId> shipmentIds);

}
