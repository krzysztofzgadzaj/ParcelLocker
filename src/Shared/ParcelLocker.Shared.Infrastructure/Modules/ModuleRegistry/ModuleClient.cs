using ParcelLocker.Shared.Abstractions.TextSerializer;

namespace ParcelLocker.Shared.Infrastructure.Modules.ModuleRegistry;

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
            .GetByKey(message.GetType().Name)
            .Where(r => r.ToType != message.GetType());;

        foreach (var registryEntry in registryEntries)
        {
            var mappedObject = MapEvent(message, registryEntry.ToType);
            await registryEntry.Action(mappedObject);
        }
    }
    
    private object MapEvent(object message, Type targetType)
        => _textSerializer.Deserialize(_textSerializer.Serialize(message), targetType);
}
