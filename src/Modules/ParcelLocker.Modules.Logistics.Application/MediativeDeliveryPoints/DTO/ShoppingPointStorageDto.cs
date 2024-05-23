namespace ParcelLocker.Modules.Logistics.Application.MediativeDeliveryPoints.DTO;

public record ShoppingPointStorageDto(
    double MaxParcelLengthInCm, 
    double MaxParcelWidthInCm, 
    double MaxParcelHeightInCm,
    double MaxParcelWeightInKg, 
    double CapacityInCm);
