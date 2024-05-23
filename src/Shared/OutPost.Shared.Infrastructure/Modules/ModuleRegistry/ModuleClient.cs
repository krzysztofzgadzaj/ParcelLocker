using System.Text.Json;
using OutPost.Shared.Abstractions.TextSerializer;

namespace OutPost.Shared.Infrastructure.Modules.ModuleRegistry;

public class ModuleClient : IModuleClient
{
    private readonly IModuleRegistry _moduleRegistry;
    private readonly ITextSerializer _textSerializer;

    public ModuleClient(IModuleRegistry moduleRegistry, ITextSerializer textSerializer)
    {
        _moduleRegistry = moduleRegistry;
        _textSerializer = textSerializer;
    }

    public async Task PublishAsync(object message)
    {
        var registryEntries = _moduleRegistry
            .GetBroadcastNotification(message.GetType().Name)
            .Where(r => r.ToType != message.GetType());;

        foreach (var registryEntry in registryEntries)
        {
            var mappedObject = MapMessage(message, registryEntry.ToType);
            await registryEntry.Action(mappedObject);
        }
    }

    public async Task<T> SendAsync<T>(string path, object args)
    {
        var registryEntry = _moduleRegistry.GetRequestNotification(path);

        if (registryEntry is null)
        {
            throw new ApplicationException();
        }

        var arguments = MapMessage(args, registryEntry.DestinationType);
        var response = await registryEntry.Action(arguments);

        return JsonSerializer.Deserialize<T>(_textSerializer.Serialize(response));
    }
    
    private object MapMessage(object message, Type targetType)
        => _textSerializer.Deserialize(_textSerializer.Serialize(message), targetType);
}
