namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities;

[Flags]
public enum FoodControlSystems
{
    NoFrost = 1 << 0,
    SpecialDiarySystem = 1 << 1
}
