using ParcelLocker.Shared.Abstractions.Exceptions.Types;

namespace ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;

public class CannotAssignParcelToUnavailableSlotException : DomainException
{
    public CannotAssignParcelToUnavailableSlotException(string text) : base(text)
    {
    }
}
