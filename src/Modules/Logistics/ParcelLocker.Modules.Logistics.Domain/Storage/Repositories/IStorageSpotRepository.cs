using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots;
using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Repositories;

public interface IStorageSpotRepository
{
    Task<IList<StoringSpot>> GetStoringSpotsByTypeAsync(AggregateId storehouseId, StoringSpotType spotType);
}
