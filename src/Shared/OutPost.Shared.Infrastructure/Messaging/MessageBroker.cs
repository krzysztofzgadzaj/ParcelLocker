using OutPost.Shared.Abstractions.Messaging;
using OutPost.Shared.Infrastructure.Messaging.Dispatchers;
using OutPost.Shared.Infrastructure.Modules.ModuleRegistry;

namespace OutPost.Shared.Infrastructure.Messaging;

public class MessageBroker : IMessageBroker
{
    private readonly MessagingOptions _messagingOptions;
    private readonly IModuleClient _moduleClient;
    private readonly IAsyncMessageDispatcher _asyncMessageDispatcher;
    
    public MessageBroker(IModuleClient moduleClient, MessagingOptions messagingOptions, IAsyncMessageDispatcher asyncMessageDispatcher)
    {
        _moduleClient = moduleClient;
        _messagingOptions = messagingOptions;
        _asyncMessageDispatcher = asyncMessageDispatcher;
    }

    public async Task PublishAsync(params IMessage[] messages)
    {
        if (messages is null)
        {
            return;
        }

        if (_messagingOptions.UseBackgroundService)
        {
            var asyncPublishTasks = messages.Select(x => _asyncMessageDispatcher.PublishAsync(x));
            await Task.WhenAll(asyncPublishTasks);
            return;
        }
        
        var publishTasks = messages.Select(x => _moduleClient.PublishAsync(x));
        await Task.WhenAll(publishTasks);
    }
}
