using Microsoft.Extensions.DependencyInjection;
using OutPost.Shared.Abstractions.TextSerializer;

namespace OutPost.Shared.Infrastructure.TextSerializer;

internal static class Extensions
{
    public static IServiceCollection AddTextSerializer(this IServiceCollection serviceCollection)
        => serviceCollection.AddSingleton<ITextSerializer, TextSerializer>();
}
