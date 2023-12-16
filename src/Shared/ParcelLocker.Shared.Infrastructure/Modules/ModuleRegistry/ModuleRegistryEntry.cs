namespace ParcelLocker.Shared.Infrastructure.Modules.ModuleRegistry;

public class ModuleRegistryEntry
{
    public ModuleRegistryEntry(Type toType, Func<object, Task> action)
    {
        ToType = toType;
        Action = action;
    }

    public string Key => ToType.Name;
    public Type ToType { get; init; }
    public Func<object, Task> Action { get; set; }
}
