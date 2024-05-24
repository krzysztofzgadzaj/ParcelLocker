using OutPost.Shared.Abstractions.Exceptions.Types;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Exceptions;

public class IncorrectParcelLockerSerialNumberException : CoreException
{
    public IncorrectParcelLockerSerialNumberException(string text) : base(text)
    {
    }
}