using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Repositories;
using OutPost.Shared.Abstractions.Events;

namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Events.External.MdpCompanyCreated;

public class MdpCompanyCreatedEventHandler : IEventHandler<MdpCompanyCreated>
{
    private readonly IMdpCompanyRepository _mdpCompanyRepository;
    
    public MdpCompanyCreatedEventHandler(IMdpCompanyRepository mdpCompanyRepository)
    {
        _mdpCompanyRepository = mdpCompanyRepository;
    }
    
    public async Task HandleAsync(MdpCompanyCreated @event)
    {
        var storedEvent = await _mdpCompanyRepository.GetById(@event.Id);

        if (storedEvent is not null)
        {
            throw new ApplicationException();
        }

        var mdpCompany = new MdpCompany(@event.Id, @event.Name, @event.AllowedMdpTypes);
        await _mdpCompanyRepository.Add(mdpCompany);
    }
}
