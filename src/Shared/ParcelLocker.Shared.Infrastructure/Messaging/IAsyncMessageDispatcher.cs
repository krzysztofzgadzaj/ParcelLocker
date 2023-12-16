using ParcelLocker.Shared.Abstractions.Messaging;

namespace ParcelLocker.Shared.Infrastructure.Messaging;

public interface IAsyncMessageDispatcher
{
    Task PublishAsync(IMessage message);
}
