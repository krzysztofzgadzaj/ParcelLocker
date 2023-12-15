using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Modules.History.Core;
using ParcelLocker.Shared.Abstractions.Modules;

namespace ParcelLocker.Modules.History.Api;

internal class HistoryModule : IModule
{
    public const string HistoryModuleUrlPrefix = "history-module";
    
    public string Name => "History_module";
    public string Path => HistoryModuleUrlPrefix;
    
    public void Register(IServiceCollection serviceCollection)
    {
        serviceCollection.AddCore();
    }

    public void Use(WebApplication webApplication)
    {
    }
}
