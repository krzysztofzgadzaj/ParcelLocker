using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.DTO;
using OutPost.Shared.Abstractions.Commands;

namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.CreateParcelLocker;

public class CreateDraftParcelLockerCommand : ICommand
{
    public List<ParcelLockerSlotDto> Slots { get; set; } = new();
    public string SerialCode { get; set; }
    public Guid MdpCompanyId { get; set; }
    public AddressDto Address { get; set; }
}
