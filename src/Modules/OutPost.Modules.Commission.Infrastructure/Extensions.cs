using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using OutPost.Modules.Commission.Application.BackgroundProcessing.Sagas.CommissionValidation;
using OutPost.Modules.Commission.Application.Clients.BackOfficeClient;
using OutPost.Modules.Commission.Application.Repositories;
using OutPost.Modules.Commission.Domain.Repositories;
using OutPost.Modules.Commission.Infrastructure.Clients;

namespace OutPost.Modules.Commission.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IBackofficeClient, BackofficeClient>();
        serviceCollection.AddScoped<IMdpRepository, MdpRepo>();
        serviceCollection.AddScoped<ICommissionRepository, ComRepo>();
        serviceCollection.AddScoped<IOutpostConfigurationRepository, OuRepo>();
        serviceCollection.AddScoped<IEventRepository, EventRepo>();
        
        serviceCollection.AddMassTransit(x =>
        {
            x.AddSagaStateMachine<ValidationSaga, ValidationSagaInstance>().InMemoryRepository();
            x.UsingInMemory((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });

        return serviceCollection;
    }
}
