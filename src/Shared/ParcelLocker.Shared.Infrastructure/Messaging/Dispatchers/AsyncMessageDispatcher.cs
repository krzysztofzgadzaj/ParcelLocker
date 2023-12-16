using ParcelLocker.Shared.Abstractions.Messaging;

namespace ParcelLocker.Shared.Infrastructure.Messaging.Dispatchers;

public class AsyncMessageDispatcher : IAsyncMessageDispatcher
{
    private readonly IMessageChannel _messageChannel;

    public AsyncMessageDispatcher(IMessageChannel messageChannel)
    {
        _messageChannel = messageChannel;
    }

    public async Task PublishAsync(IMessage message)
        => await _messageChannel.Writer.WriteAsync(message);
}
