using ParcelLocker.Modules.Backoffice.Core.Entities;
using ParcelLocker.Shared.Abstractions.Events;

namespace ParcelLocker.Modules.Backoffice.Core.Events.Internal;

public class MdpCompanyCreated : IEvent
{
    public MdpCompanyCreated(Guid id, decimal markup, string name, MdpTypes allowedMdpTypes)
    {
        Id = id;
        Markup = markup;
        Name = name;
        AllowedMdpTypes = allowedMdpTypes;
    }

    public Guid Id { get; }
    public string Name { get; }
    public decimal Markup { get; }
    public MdpTypes AllowedMdpTypes { get; }
}
