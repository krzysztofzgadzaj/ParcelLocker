using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Shipments;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Repositories;

public interface IShipmentRepository
{
    Task<List<Shipment>> GetShipmentsAsync();
}
