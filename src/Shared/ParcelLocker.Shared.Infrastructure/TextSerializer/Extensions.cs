using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Shared.Abstractions.TextSerializer;

namespace ParcelLocker.Shared.Infrastructure.TextSerializer;

internal static class Extensions
{
    public static IServiceCollection AddTextSerializer(this IServiceCollection serviceCollection)
        => serviceCollection.AddSingleton<ITextSerializer, TextSerializer>();
}
