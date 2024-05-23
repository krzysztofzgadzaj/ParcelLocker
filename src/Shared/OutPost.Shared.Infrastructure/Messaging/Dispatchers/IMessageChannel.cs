using System.Threading.Channels;
using OutPost.Shared.Abstractions.Messaging;

namespace OutPost.Shared.Infrastructure.Messaging.Dispatchers;

public interface IMessageChannel
{
    ChannelReader<IMessage> Reader { get; }
    ChannelWriter<IMessage> Writer { get; }
}