using OutPost.Shared.Abstractions.Events;

namespace OutPost.Modules.Commission.Application.Repositories;

public interface IEventRepository
{
    Task StoreAsync(IEnumerable<IEvent> events);
}

public class EventRepo : IEventRepository
{
    public Task StoreAsync(IEnumerable<IEvent> events)
    {
        throw new NotImplementedException();
    }
}