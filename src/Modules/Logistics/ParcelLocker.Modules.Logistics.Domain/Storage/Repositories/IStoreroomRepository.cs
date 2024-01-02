using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Storerooms;
using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Repositories;

public interface IStoreroomRepository
{
    Task<List<Storeroom>> GetStoreroomsAsync(AggregateId storehouseId);
}