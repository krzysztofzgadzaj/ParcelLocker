using ParcelLocker.Shared.Abstractions.Exceptions.Types;

namespace ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;

public class IncorrectParcelLockerSerialNumberException : CoreException
{
    public IncorrectParcelLockerSerialNumberException(string text) : base(text)
    {
    }
}