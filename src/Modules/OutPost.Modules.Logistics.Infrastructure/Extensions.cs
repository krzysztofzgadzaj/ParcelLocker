using Microsoft.Extensions.DependencyInjection;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Repositories;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared.Repositories;
using OutPost.Modules.Logistics.Infrastructure.Persistence;
using OutPost.Modules.Logistics.Infrastructure.Persistence.Repositories;
using OutPost.Shared.Infrastructure.Persistence.Postgres;

namespace OutPost.Modules.Logistics.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IMdpRepository, MdpRepository>()
            .AddScoped<IMdpCompanyRepository, MdpCompanyRepository>()
            .AddPostgres<LogisticsContext>();

        return serviceCollection;
    }
}
