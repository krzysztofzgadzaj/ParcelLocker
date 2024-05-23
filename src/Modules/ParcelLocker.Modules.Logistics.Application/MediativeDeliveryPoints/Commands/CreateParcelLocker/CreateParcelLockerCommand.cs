using ParcelLocker.Modules.Logistics.Application.MediativeDeliveryPoints.DTO;
using ParcelLocker.Shared.Abstractions.Commands;

namespace ParcelLocker.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.CreateParcelLocker;

public class CreateParcelLockerCommand : ICommand
{
    public IEnumerable<ParcelLockerSlotDto> Slots { get; set; }
    public string SerialCode { get; set; }
    public Guid MdpCompanyId { get; set; }
    public AddressDto Address { get; set; }
}
