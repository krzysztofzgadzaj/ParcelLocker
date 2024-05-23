using Microsoft.Extensions.DependencyInjection;
using OutPost.Modules.Commission.Application.Clients.BackOfficeClient;
using OutPost.Modules.Commission.Infrastructure.Clients;

namespace OutPost.Modules.Commission.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IBackofficeClient, BackofficeClient>();

        return serviceCollection;
    }
}