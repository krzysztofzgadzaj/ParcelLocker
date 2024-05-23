using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Shared.Abstractions.Modules;

namespace ParcelLocker.Modules.Commission.Api;

public class CommissionModule : IModule
{
    public const string CommissionModuleUrlPrefix = "commission-module";
    
    public string Name { get; } = "Commission_module";
    public string Path { get; } = CommissionModuleUrlPrefix; 
    
    public void Register(IServiceCollection serviceCollection)
    {
    }

    public void Use(WebApplication webApplication)
    {
    }
}
