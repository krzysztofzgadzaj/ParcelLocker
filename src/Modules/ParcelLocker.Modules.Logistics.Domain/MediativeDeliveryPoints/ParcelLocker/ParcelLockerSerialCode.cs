using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;

namespace ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.ParcelLocker;

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
