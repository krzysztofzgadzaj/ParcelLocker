using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OutPost.Shared.Abstractions.Messaging;
using OutPost.Shared.Infrastructure.Messaging.Dispatchers;

namespace OutPost.Shared.Infrastructure.Messaging;

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