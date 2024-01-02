using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Shipments;
using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots.Fresh;

public abstract class FreshShipmentStoringSpot : StoringSpot
{
    public double Height { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
    public double Volume => Width * Height * Length;
    public double Temperature { get; set; }
    public double AirHumidity { get; set; }
    public FoodControlSystems FoodControlSystems { get; set; }
    
    protected List<FreshShipment> Shipments { get; set; }
    
    public abstract bool HasPlaceForShipment(FreshShipment shipment);
    public abstract void AddShipment(FreshShipment shipment);
    public abstract void AddShipments(IEnumerable<FreshShipment> shipments);
    
    // TODO - Verify if you shouldn't wrap aggregateId
    public abstract void RemoveShipment(AggregateId shipmentId);
    public abstract void RemoveShipments(IEnumerable<AggregateId> shipmentIds);
}
