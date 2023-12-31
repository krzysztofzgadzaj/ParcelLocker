using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Shipments;
using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots;
using ParcelLocker.Modules.Logistics.Domain.Storage.Repositories;
using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.DomainServices;

public class ShipmentStorageDomainService
{
    private readonly IStorageSpotRepository _storageSpotRepository;

    public ShipmentStorageDomainService(IStorageSpotRepository storageSpotRepository)
    {
        _storageSpotRepository = storageSpotRepository;
    }

    public async Task<List<StoringSpot>> GetAvailableStoringSpots(AggregateId storehouseId, Shipment shipment)
    {
        var storingSpots = await _storageSpotRepository.GetStoringSpotsByTypeAsync(storehouseId, Map(shipment.ShipmentType));
        var availableStoringSpots = storingSpots.Where(x => x.HasPlaceForShipment(shipment)).ToList();

        return availableStoringSpots;
    }

    private StoringSpotType Map(ShipmentType shipmentType)
        => shipmentType switch
        {
            ShipmentType.FreshFoodShipment => StoringSpotType.Fresh,
            _ => StoringSpotType.Fresh
        };
}
