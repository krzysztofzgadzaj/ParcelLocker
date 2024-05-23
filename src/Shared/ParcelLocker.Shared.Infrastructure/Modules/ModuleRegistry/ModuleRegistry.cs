namespace ParcelLocker.Shared.Infrastructure.Modules.ModuleRegistry;

public class ModuleRegistry : IModuleRegistry
{
    private readonly List<BroadcastNotificationRegistryEntry> _moduleRegistryEntries = new();
    private readonly List<SyncModuleRegistryEntry> _syncModuleRegistryEntries = new();
    
    public void AddBroadcastNotification(BroadcastNotificationRegistryEntry broadcastNotificationRegistryEntry)
        => _moduleRegistryEntries.Add(broadcastNotificationRegistryEntry);

    public IEnumerable<BroadcastNotificationRegistryEntry> GetBroadcastNotification(string key)
        => _moduleRegistryEntries
            .Where(x => x.Key == key);

    public void AddRequestNotification(SyncModuleRegistryEntry syncModuleRegistryEntry)
        => _syncModuleRegistryEntries.Add(syncModuleRegistryEntry);

    public SyncModuleRegistryEntry GetRequestNotification(string key)
        => _syncModuleRegistryEntries
            .Find(x => x.Key == key);
}
