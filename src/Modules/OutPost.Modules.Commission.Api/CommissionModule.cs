using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OutPost.Modules.Commission.Application;
using OutPost.Modules.Commission.Infrastructure;
using OutPost.Shared.Abstractions.Modules;

namespace OutPost.Modules.Commission.Api;

public class CommissionModule : IModule
{
    public const string CommissionModuleUrlPrefix = "commission-module";
    
    public string Name { get; } = "Commission_module";
    public string Path { get; } = CommissionModuleUrlPrefix; 
    
    public void Register(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddInfrastructure()
            .AddApplication();
    }

    public void Use(WebApplication webApplication)
    {
    }
}
