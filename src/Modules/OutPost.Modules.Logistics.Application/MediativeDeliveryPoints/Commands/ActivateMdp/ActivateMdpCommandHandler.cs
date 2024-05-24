using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Exceptions;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Repositories;
using OutPost.Shared.Abstractions.Commands;

namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.ActivateMdp;

public class ActivateMdpCommandHandler : ICommandHandler<ActivateMdpCommand>
{
    private readonly IMdpRepository _mdpRepository;

    public ActivateMdpCommandHandler(IMdpRepository mdpRepository)
    {
        _mdpRepository = mdpRepository;
    }

    public async Task SendAsync(ActivateMdpCommand command)
    {
        var mediativeDeliveryPoint = await _mdpRepository.GetById(command.Id);

        if (mediativeDeliveryPoint is null)
        {
            throw new MediativeDeliveryPointNotFoundException("");
        }
        
        mediativeDeliveryPoint.Activate();
    }
}
