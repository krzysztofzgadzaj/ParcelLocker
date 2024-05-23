using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OutPost.Modules.Logistics.Infrastructure;
using OutPost.Shared.Abstractions.Modules;

namespace OutPost.Modules.Logistics.Api;

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
