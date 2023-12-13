using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Modules.Storage.Core;
using ParcelLocker.Shared.Abstractions.Modules;

namespace ParcelLocker.Modules.Storage.Api;

public class StorageModule : IModule
{
    public const string StorageModuleUrlPrefix = "storage-module";
    
    public string Name => "Storage_module";
    public string Path => StorageModuleUrlPrefix;
    
    public void Register(IServiceCollection serviceCollection)
    {
        serviceCollection.AddCore();
    }

    public void Use(WebApplication webApplication)
    {
    }
}
