using Microsoft.Extensions.DependencyInjection;
using OutPost.Shared.Abstractions.Localization;

namespace OutPost.Shared.Infrastructure.Localization;

public static class Extensions
{
    public static IServiceCollection AddGeographicalLocalization(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ILocalizationService, LocalizationService>();
        
        return serviceCollection;
    }
}
