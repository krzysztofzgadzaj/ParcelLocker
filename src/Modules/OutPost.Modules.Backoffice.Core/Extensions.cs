using Microsoft.Extensions.DependencyInjection;
using OutPost.Modules.Backoffice.Core.Repositories.MdpCompany;
using OutPost.Modules.Backoffice.Core.Repositories.OutpostConfiguration;
using OutPost.Modules.Backoffice.Core.Services.MdpCompany;
using OutPost.Modules.Backoffice.Core.Services.OutpostConfiguration;
using OutPost.Modules.Backoffice.Core.Validators;

namespace OutPost.Modules.Backoffice.Core;

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
