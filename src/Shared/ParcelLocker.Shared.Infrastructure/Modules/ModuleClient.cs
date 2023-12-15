using System.Reflection;
using ParcelLocker.Shared.Abstractions.Events;
using ParcelLocker.Shared.Infrastructure.TextSerializer;

namespace ParcelLocker.Shared.Infrastructure.Modules;

public class ModuleClient : IModuleClient
{
    private readonly IModuleRegistry _moduleRegistry;
    private readonly ITextSerializer _textSerializer;

    public ModuleClient(IModuleRegistry moduleRegistry, ITextSerializer textSerializer)
    {
        _moduleRegistry = moduleRegistry;
        _textSerializer = textSerializer;
    }

    public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : class, IEvent
    {
        var registryEntries = _moduleRegistry
            .GetByKey(@event.GetType().Name)
            .Where(r => r.ToType != @event.GetType());;

        foreach (var registryEntry in registryEntries)
        {
            var mappedObject = MapEvent(@event, registryEntry.ToType);
            await registryEntry.Action(mappedObject);
        }
    }
    
    private object MapEvent(IEvent @event, Type targetType)
        => _textSerializer.Deserialize(_textSerializer.Serialize(@event), targetType);
}
