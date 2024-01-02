using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Shipments;

public abstract class Shipment : AggregateRoot
{
    public abstract ShipmentType ShipmentType { get; }
    public string FactoryName { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
    public double Volume => Width * Height * Length;
    public double Weight { get; set; }
}
