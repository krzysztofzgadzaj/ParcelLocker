namespace ParcelLocker.Shared.Infrastructure.Modules.ModuleRegistry;

public interface IModuleRegistry
{
    void Add(ModuleRegistryEntry moduleRegistryEntry);
    IEnumerable<ModuleRegistryEntry> GetByKey(string key);
}
