using OutPost.Shared.Abstractions.Events;

namespace OutPost.Modules.Backoffice.Core.Events.Internal;

public class OutpostMarkupChanged : IEvent
{
    public OutpostMarkupChanged(decimal markup)
    {
        Markup = markup;
    }

    public decimal Markup { get; }
}
