using Microsoft.Extensions.DependencyInjection;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Repositories;
using OutPost.Modules.Logistics.Infrastructure.Repositories;


namespace OutPost.Modules.Logistics.Infrastructure;

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
