using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots;
using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots.Fresh;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Storerooms;

public abstract class Storeroom
{
    public string Name { get; set; }
    public List<Fridge> Fridges { get; set; }
}
