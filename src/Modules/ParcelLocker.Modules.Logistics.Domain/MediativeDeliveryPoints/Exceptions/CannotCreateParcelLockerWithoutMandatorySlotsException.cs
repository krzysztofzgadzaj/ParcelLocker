using ParcelLocker.Shared.Abstractions.Exceptions.Types;

namespace ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;

public class CannotCreateParcelLockerWithoutMandatorySlotsException : CoreException
{
    public CannotCreateParcelLockerWithoutMandatorySlotsException(string text) : base(text)
    {
    }
}