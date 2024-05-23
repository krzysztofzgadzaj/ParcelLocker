using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Shared.Abstractions.Localization;

namespace ParcelLocker.Shared.Infrastructure.Localization;

public static class Extensions
{
    public static IServiceCollection AddGeographicalLocalization(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ILocalizationService, LocalizationService>();
        
        return serviceCollection;
    }
}
