using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;

namespace ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.ShoppingPoint;

public class ShoppingPointIdentifier
{
    public ShoppingPointIdentifier(string identifier)
    {
        if (string.IsNullOrEmpty(identifier))
        {
            throw new IncorrectParcelLockerSerialNumberException($"Serial number ${identifier} is incorrect");
        }
        
        Identifier = identifier;
    }

    public string Identifier { get; init; }
}
