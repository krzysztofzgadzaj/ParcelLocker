using OutPost.Shared.Abstractions.Exceptions.Types;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;

public class CannotAssignParcelToUnavailableSlotException : DomainException
{
    public CannotAssignParcelToUnavailableSlotException(string text) : base(text)
    {
    }
}
