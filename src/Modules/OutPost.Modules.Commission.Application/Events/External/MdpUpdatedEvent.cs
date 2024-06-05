using OutPost.Shared.Abstractions.Events;

namespace OutPost.Modules.Commission.Application.Events.External;

public record MdpUpdatedEvent(Guid Id, decimal Markup) : IEvent;
