using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Materialization;
using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Storerooms;

public abstract class Storeroom
{
    public string Name { get; set; }
    public double Temperature { get; set; }
    public IList<StoringSpot> StoringSpots { get; set; }

    public abstract IList<MaterializedContainer> MaterializeContainers();
}
