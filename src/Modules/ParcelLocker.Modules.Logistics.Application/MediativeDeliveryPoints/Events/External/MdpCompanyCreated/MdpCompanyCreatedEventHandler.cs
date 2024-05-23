using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints;
using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Repositories;
using ParcelLocker.Shared.Abstractions.Events;

namespace ParcelLocker.Modules.Logistics.Application.MediativeDeliveryPoints.Events.External.MdpCompanyCreated;

public class MdpCompanyCreatedEventHandler : IEventHandler<MdpCompanyCreated>
{
    private readonly IMdpCompanyRepository _mdpCompanyRepository;
    
    public MdpCompanyCreatedEventHandler(IMdpCompanyRepository mdpCompanyRepository)
    {
        _mdpCompanyRepository = mdpCompanyRepository;
    }
    
    public async Task HandleAsync(MdpCompanyCreated @event)
    {
        var storedEvent = await _mdpCompanyRepository.GetById(new MdpCompanyId(@event.Id));

        if (storedEvent is not null)
        {
            throw new ApplicationException();
        }

        var mdpCompany = new MdpCompany(new MdpCompanyId(@event.Id), @event.Name, @event.AllowedMdpTypes);
        await _mdpCompanyRepository.Add(mdpCompany);
    }
}
