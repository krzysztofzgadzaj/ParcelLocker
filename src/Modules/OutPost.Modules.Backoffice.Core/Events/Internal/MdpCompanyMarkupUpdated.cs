using OutPost.Shared.Abstractions.Events;

namespace OutPost.Modules.Backoffice.Core.Events.Internal;

public class MdpCompanyMarkupUpdated : IEvent
{
    public MdpCompanyMarkupUpdated(Guid id, decimal markup)
    {
        Id = id;
        Markup = markup;
    }

    public Guid Id { get; }
    public decimal Markup { get; }
}
