using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Shipments;
using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots.Standard;

public class MetalRack : StandardStoringSpot
{
    protected List<StandardShipment> Shipments { get; set; }
    public override StoringSpotType StoringSpotType => StoringSpotType.Standard;
    
    public override bool HasPlaceForShipment(StandardShipment shipment)
    {
        throw new NotImplementedException();
    }

    public override void AddShipment(StandardShipment shipment)
    {
        throw new NotImplementedException();
    }

    public override void AddShipments(IEnumerable<StandardShipment> shipments)
    {
        throw new NotImplementedException();
    }

    public override void RemoveShipment(AggregateId shipmentId)
    {
        throw new NotImplementedException();
    }

    public override void RemoveShipments(IEnumerable<AggregateId> shipmentIds)
    {
        throw new NotImplementedException();
    }
}
