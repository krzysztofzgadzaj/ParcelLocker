using ParcelLocker.Shared.Abstractions.Exceptions.Types;

namespace ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;

public class IncorrectParcelLockerSlotDimensionException : CoreException
{
    public IncorrectParcelLockerSlotDimensionException(string text) : base(text)
    {
    }
}