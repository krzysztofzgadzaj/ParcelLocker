using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints;
using OutPost.Shared.Abstractions.Commands;

namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.ActivateMdp;

public record ActivateMdpCommand(Guid Id) : ICommand;
