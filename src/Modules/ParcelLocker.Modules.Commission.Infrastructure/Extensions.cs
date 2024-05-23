using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Modules.Commission.Application.Clients.BackOfficeClient;
using ParcelLocker.Modules.Commission.Infrastructure.Clients;

namespace ParcelLocker.Modules.Commission.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IBackofficeClient, BackofficeClient>();

        return serviceCollection;
    }
}