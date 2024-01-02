using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Storerooms;
using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots;
using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots.Fresh;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Materialization;

public class MaterializedContainer
{
    public double Temperature { get; private set; }
    public bool HasNoFrostSystem { get; private set; }

    public MaterializedContainer(Storeroom storeroom, StoringSpot storingSpot)
    {
        if (storingSpot is FreshShipmentStoringSpot callMeGenius)
        {
            Temperature = callMeGenius.Temperature;
            HasNoFrostSystem = true;
        }
        else if (storeroom is HallStoreroom hehe)
        {
            Temperature = hehe.Temperature;
            HasNoFrostSystem = false;
        }
    }

    public MaterializedContainer(HallStoreroom hallStoreroom, StoringSpot storingSpot)
    {
        
    }

    public MaterializedContainer(FreshShipmentStoringSpot freshShipmentStoringSpot)
    {
        Temperature = freshShipmentStoringSpot.Temperature;
        HasNoFrostSystem = (freshShipmentStoringSpot.FoodControlSystems & FoodControlSystems.NoFrost) != FoodControlSystems.None;
    }
}
