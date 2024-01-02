using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Materialization;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Storerooms;

public class HallStoreroom : Storeroom
{
    public override IList<MaterializedContainer> MaterializeContainers()
    {
        return StoringSpots.Select(x => new MaterializedContainer(this, x)).ToList();
    }
}
