using OutPost.Shared.Abstractions.Messaging;

namespace OutPost.Shared.Infrastructure.Messaging.Dispatchers;

public interface IAsyncMessageDispatcher
{
    Task PublishAsync(IMessage message);
}
