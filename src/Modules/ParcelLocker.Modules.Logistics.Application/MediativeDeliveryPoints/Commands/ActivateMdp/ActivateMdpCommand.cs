using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints;
using ParcelLocker.Shared.Abstractions.Commands;

namespace ParcelLocker.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.ActivateMdp;

public record ActivateMdpCommand(MediativeDeliveryPointId Id) : ICommand;
