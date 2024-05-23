namespace ParcelLocker.Shared.Infrastructure.Modules.ModuleRegistry;

public interface IModuleRegistry
{
    void AddAsyncCommunication(ModuleRegistryEntry moduleRegistryEntry);
    IEnumerable<ModuleRegistryEntry> GetAsyncByKey(string key);

    void AddSyncCommunication(SyncModuleRegistryEntry syncModuleRegistryEntry);
    SyncModuleRegistryEntry GetSyncByKey(string key);
}
