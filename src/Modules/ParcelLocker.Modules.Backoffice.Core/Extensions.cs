using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Modules.Backoffice.Core.Repositories.MdpCompany;
using ParcelLocker.Modules.Backoffice.Core.Repositories.OutpostConfiguration;
using ParcelLocker.Modules.Backoffice.Core.Services.MdpCompany;
using ParcelLocker.Modules.Backoffice.Core.Services.OutpostConfiguration;
using ParcelLocker.Modules.Backoffice.Core.Validators;

namespace ParcelLocker.Modules.Backoffice.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
        => serviceCollection
            .AddSingleton<IMdpCompanyRepository, MdpCompanyRepository>()
            .AddSingleton<IOutpostConfigurationRepository, OutpostConfigurationRepository>()
            .AddScoped<IOutpostConfigurationService, OutpostConfigurationService>()
            .AddScoped<IMdpCompanyService, MdpCompanyService>()
            .AddScoped<MdpCompanyValidator>();
}
