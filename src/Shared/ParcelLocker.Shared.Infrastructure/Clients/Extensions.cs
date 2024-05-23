using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Shared.Abstractions.Clients;

namespace ParcelLocker.Shared.Infrastructure.Clients;

public static class Extensions
{
    public static IServiceCollection AddInMemoryClient(this IServiceCollection serviceCollection)
        => serviceCollection.AddScoped<IClient, InMemoryClient>();
}
