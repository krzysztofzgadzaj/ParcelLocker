using OutPost.Modules.Commission.Domain.Repositories;
using OutPost.Shared.Abstractions.Events;

namespace OutPost.Modules.Commission.Application.Events.External;

public class MdpUpdatedEventHandler : IEventHandler<MdpUpdatedEvent>
{
    private readonly IMdpRepository _mdpRepository;

    public MdpUpdatedEventHandler(IMdpRepository mdpRepository)
    {
        _mdpRepository = mdpRepository;
    }

    public async Task HandleAsync(MdpUpdatedEvent @event)
    {
        var mdp = await _mdpRepository.GetByIdAsync(@event.Id);

        if (mdp is null)
        {
            throw new ApplicationException();
        }
        
        mdp.UpdateMarkup(@event.Markup);
        await _mdpRepository.UpdateAsync(mdp);
    }
}
