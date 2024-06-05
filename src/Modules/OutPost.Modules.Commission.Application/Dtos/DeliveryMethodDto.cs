namespace OutPost.Modules.Commission.Application.Dtos;

public record DeliveryMethodDto(
    DeliveryMethodType DeliveryMethodType,
    Guid? MdpId,
    AddressDto? Address);
    