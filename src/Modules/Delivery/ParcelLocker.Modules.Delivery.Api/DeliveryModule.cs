using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Modules.Delivery.Application;
using ParcelLocker.Modules.Delivery.Domain;
using ParcelLocker.Modules.Delivery.Infrastructure;
using ParcelLocker.Shared.Abstractions.Modules;

namespace ParcelLocker.Modules.Delivery.Api;

public class DeliveryModule : IModule
{
    public const string DeliveryModuleUrlPrefix = "delivery-module";
    
    public string Name => "Delivery-module";
    public string Path => DeliveryModuleUrlPrefix;
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
