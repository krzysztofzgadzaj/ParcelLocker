using OutPost.Modules.Commission.Application.Dtos;
using OutPost.Shared.Abstractions.Commands;

namespace OutPost.Modules.Commission.Application.Commands;

public record CreateCommissionCommand(
    ParcelParametersDto ParcelParametersDto,
    DeliveryMethodDto ParcelStartingPoint,
    DeliveryMethodDto ParcelDeliveryPoint) : ICommand;
