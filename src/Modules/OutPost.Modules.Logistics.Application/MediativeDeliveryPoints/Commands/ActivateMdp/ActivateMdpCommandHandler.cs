using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Exceptions;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Repositories;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointDrafts.Repositories;
using OutPost.Shared.Abstractions.Commands;

namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.ActivateMdp;

public class ActivateMdpCommandHandler : ICommandHandler<ActivateMdpCommand>
{
    private readonly IMdpDraftRepository _mdpDraftRepository;

    public ActivateMdpCommandHandler(IMdpDraftRepository mdpDraftRepository)
    {
        _mdpDraftRepository = mdpDraftRepository;
    }

    public async Task SendAsync(ActivateMdpCommand command)
    {
        var mediativeDeliveryPoint = await _mdpDraftRepository.GetById(command.Id);

        if (mediativeDeliveryPoint is null)
        {
            throw new MediativeDeliveryPointNotFoundException("");
        }
        
        var mdp = mediativeDeliveryPoint.Activate();
    }
}
