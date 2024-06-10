using OutPost.Shared.Abstractions.Events;

namespace OutPost.Modules.Commission.Application.Repositories;

public interface IEventRepository
{
    Task StoreAsync(IEnumerable<IEvent> events);
}
