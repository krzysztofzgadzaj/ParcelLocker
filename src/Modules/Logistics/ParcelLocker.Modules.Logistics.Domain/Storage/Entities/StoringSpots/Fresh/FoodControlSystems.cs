namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots.Fresh;

[Flags]
public enum FoodControlSystems
{
    None = 0,
    NoFrost = 1 << 0,
    SpecialDiarySystem = 1 << 1
}
