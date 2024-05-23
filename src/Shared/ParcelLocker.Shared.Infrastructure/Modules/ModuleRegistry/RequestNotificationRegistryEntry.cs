namespace ParcelLocker.Shared.Infrastructure.Modules.ModuleRegistry;

public class SyncModuleRegistryEntry
{
    public SyncModuleRegistryEntry(Type destinationType, Func<object, Task<object>> action, string path)
    {
        DestinationType = destinationType;
        Action = action;
        Path = path;
    }

    public string Key => Path;
    public Type DestinationType { get; init; }
    public string Path { get; init; }
    public Func<object, Task<object>> Action { get; set; }
}
