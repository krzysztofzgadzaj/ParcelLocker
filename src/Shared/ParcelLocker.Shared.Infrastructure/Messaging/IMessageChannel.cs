using System.Threading.Channels;
using ParcelLocker.Shared.Abstractions.Messaging;

namespace ParcelLocker.Shared.Infrastructure.Messaging;

public interface IMessageChannel
{
    ChannelReader<IMessage> Reader { get; }
    ChannelWriter<IMessage> Writer { get; }
}