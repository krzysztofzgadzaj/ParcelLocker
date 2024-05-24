using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.ShoppingPoints;

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
