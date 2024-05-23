namespace ParcelLocker.Shared.Infrastructure.Modules.ModuleRegistry;

public class ModuleRegistry : IModuleRegistry
{
    private readonly List<ModuleRegistryEntry> _moduleRegistryEntries = new();
    private readonly List<SyncModuleRegistryEntry> _syncModuleRegistryEntries = new();
    
    public void AddAsyncCommunication(ModuleRegistryEntry moduleRegistryEntry)
        => _moduleRegistryEntries.Add(moduleRegistryEntry);

    public IEnumerable<ModuleRegistryEntry> GetAsyncByKey(string key)
        => _moduleRegistryEntries
            .Where(x => x.Key == key);

    public void AddSyncCommunication(SyncModuleRegistryEntry syncModuleRegistryEntry)
        => _syncModuleRegistryEntries.Add(syncModuleRegistryEntry);

    public SyncModuleRegistryEntry GetSyncByKey(string key)
        => _syncModuleRegistryEntries
            .Find(x => x.Key == key);
}
