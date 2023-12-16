using System.Threading.Channels;
using ParcelLocker.Shared.Abstractions.Messaging;

namespace ParcelLocker.Shared.Infrastructure.Messaging;

public class MessageChannel : IMessageChannel
{
    private readonly Channel<IMessage> _messages = Channel.CreateUnbounded<IMessage>();

    public ChannelReader<IMessage> Reader => _messages.Reader;
    public ChannelWriter<IMessage> Writer => _messages.Writer;
}
