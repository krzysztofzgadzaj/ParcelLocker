using System.Threading.Channels;
using ParcelLocker.Shared.Abstractions.Messaging;

namespace ParcelLocker.Shared.Infrastructure.Messaging.Dispatchers;

public interface IMessageChannel
{
    ChannelReader<IMessage> Reader { get; }
    ChannelWriter<IMessage> Writer { get; }
}