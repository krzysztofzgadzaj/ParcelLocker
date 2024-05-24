using OutPost.Shared.Abstractions.Exceptions.Types;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Exceptions;

public class IncorrectParcelLockerSlotDimensionException : CoreException
{
    public IncorrectParcelLockerSlotDimensionException(string text) : base(text)
    {
    }
}