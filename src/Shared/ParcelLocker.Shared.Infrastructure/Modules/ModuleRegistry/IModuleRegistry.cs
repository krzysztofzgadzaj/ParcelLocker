namespace ParcelLocker.Shared.Infrastructure.Modules.ModuleRegistry;

public interface IModuleRegistry
{
    void AddBroadcastNotification(BroadcastNotificationRegistryEntry broadcastNotificationRegistryEntry);
    IEnumerable<BroadcastNotificationRegistryEntry> GetBroadcastNotification(string key);

    void AddRequestNotification(SyncModuleRegistryEntry syncModuleRegistryEntry);
    SyncModuleRegistryEntry GetRequestNotification(string key);
}
