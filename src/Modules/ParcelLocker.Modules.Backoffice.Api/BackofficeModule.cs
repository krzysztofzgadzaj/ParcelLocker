using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Modules.Backoffice.Core;
using ParcelLocker.Modules.Backoffice.Core.Services.OutpostConfiguration;
using ParcelLocker.Shared.Abstractions.Modules;
using ParcelLocker.Shared.Infrastructure.Modules;

namespace ParcelLocker.Modules.Backoffice.Api;

public class BackofficeModule : IModule
{
    public const string BackofficeModuleUrlPrefix = "backoffice-module";
    public const string BackofficeModuleGroupName = "Backoffice_module";

    public string Name { get; } = BackofficeModuleGroupName;
    public string Path { get; } = BackofficeModuleUrlPrefix; 
    
    public void Register(IServiceCollection serviceCollection)
    {
        serviceCollection.AddCore();
    }

    public void Use(WebApplication webApplication)
    {
        webApplication.UseRequestRegistration().Display(
            "/outpost-configuration/markup", 
            (IServiceProvider serviceCollection, object args) 
                => serviceCollection.GetRequiredService<IOutpostConfigurationService>().GetSingle());
    }
}
