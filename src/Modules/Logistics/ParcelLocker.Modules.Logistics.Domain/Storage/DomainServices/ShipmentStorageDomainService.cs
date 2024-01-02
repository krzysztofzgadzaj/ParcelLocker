using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Materialization;
using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Shipments;
using ParcelLocker.Modules.Logistics.Domain.Storage.Factories;
using ParcelLocker.Modules.Logistics.Domain.Storage.Repositories;
using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.DomainServices;

public class ShipmentStorageDomainService
{
    private readonly IStoreroomRepository _storeroomRepository;
    private readonly StoringSpecificationFactory _storingSpecificationFactory;

    public ShipmentStorageDomainService(IStoreroomRepository storeroomRepository, StoringSpecificationFactory storingSpecificationFactory)
    {
        _storeroomRepository = storeroomRepository;
        _storingSpecificationFactory = storingSpecificationFactory;
    }

    public async Task<List<MaterializedContainer>> GetAvailableStoringSpots(AggregateId storehouseId, Shipment shipment)
    {
        var storerooms = await _storeroomRepository.GetStoreroomsAsync(storehouseId);
        var conditions = _storingSpecificationFactory.GetConditions(shipment);
        var materializedStoringSpots = storerooms.SelectMany(x => x.StoringSpots.Select(y => new MaterializedContainer(x, y)));

        var matchingStoringSpots = materializedStoringSpots.Where(x => conditions.Check(x)).ToList();

        return matchingStoringSpots;
    }
}
