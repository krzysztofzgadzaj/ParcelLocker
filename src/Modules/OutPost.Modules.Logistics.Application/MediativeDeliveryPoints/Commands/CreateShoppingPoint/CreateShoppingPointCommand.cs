using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.DTO;
using OutPost.Shared.Abstractions.Commands;

namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.CreateShoppingPoint;

public class CreateShoppingPointCommand : ICommand
{
    public ShoppingPointStorageDto ShoppingPointStorageDto { get; set; }
    public string ShoppingPointIdentifier { get; set; }
    public Guid MdpCompanyId { get; set; }
    public AddressDto Address { get; set; }
}
