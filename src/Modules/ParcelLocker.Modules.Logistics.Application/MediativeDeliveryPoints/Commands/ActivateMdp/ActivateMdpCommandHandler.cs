using ParcelLocker.Modules.Logistics.Application.MediativeDeliveryPoints.Exceptions;
using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Repositories;
using ParcelLocker.Shared.Abstractions.Commands;

namespace ParcelLocker.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.ActivateMdp;

public class ActivateMdpCommandHandler : ICommandHandler<ActivateMdpCommand>
{
    private readonly IMdpRepository _mdpRepository;

    public ActivateMdpCommandHandler(IMdpRepository mdpRepository)
    {
        _mdpRepository = mdpRepository;
    }

    public async Task SendAsync(ActivateMdpCommand command)
    {
        var parcelLocker = await _mdpRepository.GetById(command.Id);

        if (parcelLocker is null)
        {
            throw new ParcelLockerNotFoundException("");
        }
        
        parcelLocker.Activate();
    }
}
