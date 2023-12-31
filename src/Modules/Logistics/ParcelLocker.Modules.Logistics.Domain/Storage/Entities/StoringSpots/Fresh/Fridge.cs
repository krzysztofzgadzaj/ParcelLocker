using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Shipments;
using ParcelLocker.Modules.Logistics.Domain.Storage.Exceptions;
using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots.Fresh;

public class Fridge : FreshShipmentStoringSpot
{
    public override StoringSpotType StoringSpotType => StoringSpotType.Fresh;

    public override bool HasPlaceForShipment(Shipment shipment)
    {
        return GetSpaceLeft() - shipment.Volume > 0;
    }

    public override void AddShipment(Shipment shipment)
    {
        if (!HasPlaceForShipment(shipment))
        {
            throw new StoringSpotIsFullException(
                $"Load with id: {shipment.Id} cannot be stored in storing spot with id: {Id}");
        }
        
        Shipments.Add(shipment);
    }

    public override void AddShipments(IEnumerable<Shipment> shipments)
    {
        foreach (var package in shipments)
        {
            AddShipment(package);
        }
    }

    public override void RemoveShipment(AggregateId shipmentId)
    {
        var shipment = Shipments.FirstOrDefault(x => x.Id == shipmentId);
        Shipments.Remove(shipment);
    }

    public override void RemoveShipments(IEnumerable<AggregateId> shipmentIds)
    {
        foreach (var shipment in shipmentIds)
        {
            RemoveShipment(shipment);
        }
    }

    private double GetSpaceLeft()
    {
        return Volume - Shipments.Sum(x => x.Volume);
    }
}
