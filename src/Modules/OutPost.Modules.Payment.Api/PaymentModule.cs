using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OutPost.Shared.Abstractions.Modules;

namespace OutPost.Modules.Payment.Api;

public class PaymentModule : IModule
{
    public const string PaymentModuleUrlPrefix = "payment-module";
    public const string PaymentModuleGroupName = "Payment_module";

    public string Name { get; } = PaymentModuleGroupName;
    public string Path { get; } = PaymentModuleUrlPrefix; 
    
    public void Register(IServiceCollection serviceCollection)
    {
    }

    public void Use(WebApplication webApplication)
    {
    }
}
