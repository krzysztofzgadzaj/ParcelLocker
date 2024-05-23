namespace OutPost.Shared.Infrastructure.Modules.ModuleRegistry;

public class BroadcastNotificationRegistryEntry
{
    public BroadcastNotificationRegistryEntry(Type toType, Func<object, Task> action)
    {
        ToType = toType;
        Action = action;
    }

    public string Key => ToType.Name;
    public Type ToType { get; init; }
    public Func<object, Task> Action { get; set; }
}
