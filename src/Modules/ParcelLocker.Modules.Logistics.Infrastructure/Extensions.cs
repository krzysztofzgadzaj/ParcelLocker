using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Repositories;
using ParcelLocker.Modules.Logistics.Infrastructure.Repositories;

namespace ParcelLocker.Modules.Logistics.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSingleton<IMdpRepository, MdpRepository>()
            .AddSingleton<IMdpCompanyRepository, MdpCompanyRepository>();

        return serviceCollection;
    }
}
