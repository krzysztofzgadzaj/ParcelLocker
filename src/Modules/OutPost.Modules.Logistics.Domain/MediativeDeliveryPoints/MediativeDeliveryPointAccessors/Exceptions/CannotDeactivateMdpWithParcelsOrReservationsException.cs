using OutPost.Shared.Abstractions.Exceptions.Types;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Exceptions;

public class CannotDeactivateMdpWithParcelsOrReservationsException : CoreException
{
    public CannotDeactivateMdpWithParcelsOrReservationsException(string text) : base(text)
    {
    }
}