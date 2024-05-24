using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Exceptions;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared;

public class ParcelLockerSerialCode
{
    public ParcelLockerSerialCode(string serialNumber)
    {
        if (string.IsNullOrEmpty(serialNumber))
        {
            throw new IncorrectParcelLockerSerialNumberException($"Serial number ${serialNumber} is incorrect");
        }
        
        SerialNumber = serialNumber;
    }
    
    public string SerialNumber { get; init; }
}
