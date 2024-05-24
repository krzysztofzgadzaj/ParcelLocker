using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.DTO;
using OutPost.Shared.Abstractions.Commands;

namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.CreateParcelLocker;

public class CreateDraftParcelLockerCommand : ICommand
{
    public IEnumerable<ParcelLockerSlotDto> Slots { get; set; }
    public string SerialCode { get; set; }
    public Guid MdpCompanyId { get; set; }
    public AddressDto Address { get; set; }
}
