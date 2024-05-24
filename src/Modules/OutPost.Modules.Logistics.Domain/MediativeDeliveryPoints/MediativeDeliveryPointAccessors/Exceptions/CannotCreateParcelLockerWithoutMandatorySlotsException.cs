using OutPost.Shared.Abstractions.Exceptions.Types;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Exceptions;

public class CannotCreateParcelLockerWithoutMandatorySlotsException : CoreException
{
    public CannotCreateParcelLockerWithoutMandatorySlotsException(string text) : base(text)
    {
    }
}