using Microsoft.Extensions.DependencyInjection;

namespace ParcelLocker.Shared.Infrastructure.Modules.ModuleRegistry;

class RequestRegistry : IRequestRegistry
{
    private readonly IModuleRegistry _moduleRegistry;
    private readonly IServiceProvider _serviceProvider;

    public RequestRegistry(IModuleRegistry moduleRegistry, IServiceProvider serviceProvider)
    {
        _moduleRegistry = moduleRegistry;
        _serviceProvider = serviceProvider;
    }

    public void Display<TArg, TResult>(string path, Func<IServiceProvider, TArg, Task<TResult>> action) 
        where TArg : class 
        where TResult : class
    {
        _moduleRegistry.AddRequestNotification(new SyncModuleRegistryEntry(
            typeof(TArg),
            async (args) =>
            {
                using var scope = _serviceProvider.CreateScope();
                var result = await action(scope.ServiceProvider, (TArg) args);
                return result;
            }, 
            path));
    }
}
