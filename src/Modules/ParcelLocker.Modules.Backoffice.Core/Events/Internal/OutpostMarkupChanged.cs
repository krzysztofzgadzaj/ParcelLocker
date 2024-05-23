using ParcelLocker.Shared.Abstractions.Events;

namespace ParcelLocker.Modules.Backoffice.Core.Events.Internal;

public class OutpostMarkupChanged : IEvent
{
    public OutpostMarkupChanged(decimal markup)
    {
        Markup = markup;
    }

    public decimal Markup { get; }
}
