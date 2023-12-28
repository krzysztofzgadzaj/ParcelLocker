using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Modules.Logistics.Application;
using ParcelLocker.Modules.Logistics.Domain;
using ParcelLocker.Modules.Logistics.Infrastructure;
using ParcelLocker.Shared.Abstractions.Modules;

namespace ParcelLocker.Modules.Logistics.Api;

public class LogisticsModule : IModule
{
    public const string LogisticsModuleUrlPrefix = "logistics-module";
    
    public string Name => "Logistics-module";
    public string Path => LogisticsModuleUrlPrefix;
    public void Register(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddInfrastructure()
            .AddApplication()
            .AddDomain();
    }

    public void Use(WebApplication webApplication)
    {
    }
}
