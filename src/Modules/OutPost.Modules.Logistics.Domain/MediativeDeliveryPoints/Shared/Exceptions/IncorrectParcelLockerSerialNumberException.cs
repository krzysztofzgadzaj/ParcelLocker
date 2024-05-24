using OutPost.Shared.Abstractions.Exceptions.Types;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared.Exceptions;

public class IncorrectParcelLockerSerialNumberException : CoreException
{
    public IncorrectParcelLockerSerialNumberException(string text) : base(text)
    {
    }
}
