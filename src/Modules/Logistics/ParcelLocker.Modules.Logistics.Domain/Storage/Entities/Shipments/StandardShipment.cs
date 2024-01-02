namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Shipments;

public class StandardShipment : Shipment
{
    public override ShipmentType ShipmentType => ShipmentType.StandardShipment;
    public bool IsBreakable { get; set; }
    public bool IsPriority { get; set; }
}
