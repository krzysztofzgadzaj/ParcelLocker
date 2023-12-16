using ParcelLocker.Shared.Abstractions.Messaging;

namespace ParcelLocker.Shared.Infrastructure.Messaging.Dispatchers;

public interface IAsyncMessageDispatcher
{
    Task PublishAsync(IMessage message);
}
