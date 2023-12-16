using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Shared.Abstractions.Messaging;
using ParcelLocker.Shared.Infrastructure.Messaging.Dispatchers;

namespace ParcelLocker.Shared.Infrastructure.Messaging;

internal static class Extensions
{
    private const string MessageSectionName = "Messaging";
    
    public static IServiceCollection AddMessageBroker(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddSingleton<IMessageBroker, MessageBroker>()
            .AddSingleton<IMessageChannel, MessageChannel>()
            .AddSingleton<IAsyncMessageDispatcher, AsyncMessageDispatcher>()
            .AddHostedService<AsyncMessageJob>();

        var messageOptions = configuration.GetSection(MessageSectionName).Get<MessagingOptions>();
        serviceCollection.AddSingleton(messageOptions);
        
        return serviceCollection;
    }
}