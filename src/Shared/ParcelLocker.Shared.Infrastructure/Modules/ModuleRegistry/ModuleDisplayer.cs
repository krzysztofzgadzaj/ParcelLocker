namespace ParcelLocker.Shared.Infrastructure.Modules.ModuleRegistry;

class ModuleDisplayer : IModuleDisplayer
{
    private readonly IModuleRegistry _moduleRegistry;
    private readonly IServiceProvider _serviceProvider;

    public ModuleDisplayer(IModuleRegistry moduleRegistry, IServiceProvider serviceProvider)
    {
        _moduleRegistry = moduleRegistry;
        _serviceProvider = serviceProvider;
    }

    public void Display<TArg, TResult>(string path, Func<IServiceProvider, TArg, Task<TResult>> action) 
        where TArg : class 
        where TResult : class
    {
        _moduleRegistry.AddSyncCommunication(new SyncModuleRegistryEntry(
            typeof(TArg),
            async (args) =>
            {
                var result = await action(_serviceProvider, (TArg) args);
                return result;
            }, 
            path));
    }
}
