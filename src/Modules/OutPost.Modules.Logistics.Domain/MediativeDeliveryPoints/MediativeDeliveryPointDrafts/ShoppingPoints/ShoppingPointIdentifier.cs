using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Exceptions;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointDrafts.ShoppingPoints;

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
