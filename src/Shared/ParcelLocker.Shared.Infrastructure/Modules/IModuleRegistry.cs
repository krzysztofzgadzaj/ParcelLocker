namespace ParcelLocker.Shared.Infrastructure.Modules;

public interface IModuleRegistry
{
    void Add(ModuleRegistryEntry moduleRegistryEntry);
    IEnumerable<ModuleRegistryEntry> GetByKey(string key);
}
