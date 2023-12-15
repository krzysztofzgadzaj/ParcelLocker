namespace ParcelLocker.Shared.Infrastructure.Modules;

public class ModuleRegistry : IModuleRegistry
{
    private readonly List<ModuleRegistryEntry> _moduleRegistryEntries = new();
    
    public void Add(ModuleRegistryEntry moduleRegistryEntry)
        => _moduleRegistryEntries.Add(moduleRegistryEntry);

    public IEnumerable<ModuleRegistryEntry> GetByKey(string key)
        => _moduleRegistryEntries
            .Where(x => x.Key == key);
}
