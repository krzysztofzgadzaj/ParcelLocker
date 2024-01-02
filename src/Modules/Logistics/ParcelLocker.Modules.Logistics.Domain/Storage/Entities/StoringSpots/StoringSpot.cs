using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Storerooms;
using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots;

public abstract class StoringSpot : AggregateRoot
{
    public AggregateId StoreroomId { get; set; }
    public Storeroom Storeroom { get; set; }
    public abstract StoringSpotType StoringSpotType { get; }
}
