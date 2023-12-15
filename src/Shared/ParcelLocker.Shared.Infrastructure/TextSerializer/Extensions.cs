using Microsoft.Extensions.DependencyInjection;

namespace ParcelLocker.Shared.Infrastructure.TextSerializer;

public static class Extensions
{
    public static IServiceCollection AddTextSerializer(this IServiceCollection serviceCollection)
        => serviceCollection.AddSingleton<ITextSerializer, TextSerializer>();
}
