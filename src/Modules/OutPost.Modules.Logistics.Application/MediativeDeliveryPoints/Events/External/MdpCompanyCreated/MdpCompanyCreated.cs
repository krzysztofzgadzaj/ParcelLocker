using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared;
using OutPost.Shared.Abstractions.Events;

namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Events.External.MdpCompanyCreated;

public class MdpCompanyCreated : IEvent
{
    public MdpCompanyCreated(Guid id, string name, MdpTypes allowedMdpTypes)
    {
        Id = id;
        Name = name;
        AllowedMdpTypes = allowedMdpTypes;
    }

    public Guid Id { get; }
    public string Name { get; }
    public MdpTypes AllowedMdpTypes { get; }
}
