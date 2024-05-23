using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Modules.Logistics.Infrastructure;
using ParcelLocker.Shared.Abstractions.Modules;

namespace ParcelLocker.Modules.Logistics.Api;

public class LogisticsModule : IModule
{
    public const string LogisticsModuleUrlPrefix = "logistics-module";
    public const string LogisticsModuleGroupName = "Logistics_module";
    
    public string Name { get; } = LogisticsModuleGroupName;
    public string Path { get; } = LogisticsModuleUrlPrefix; 
    
    public void Register(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddInfrastructure();
    }

    public void Use(WebApplication webApplication)
    {
    }
}
