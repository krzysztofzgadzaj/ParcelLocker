using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.ParcelLockers;

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
