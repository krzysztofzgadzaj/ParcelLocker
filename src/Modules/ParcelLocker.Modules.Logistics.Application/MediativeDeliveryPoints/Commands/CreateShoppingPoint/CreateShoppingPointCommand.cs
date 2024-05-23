using ParcelLocker.Modules.Logistics.Application.MediativeDeliveryPoints.DTO;
using ParcelLocker.Shared.Abstractions.Commands;

namespace ParcelLocker.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.CreateShoppingPoint;

public class CreateShoppingPointCommand : ICommand
{
    public ShoppingPointStorageDto ShoppingPointStorageDto { get; set; }
    public string ShoppingPointIdentifier { get; set; }
    public Guid MdpCompanyId { get; set; }
    public AddressDto Address { get; set; }
}
