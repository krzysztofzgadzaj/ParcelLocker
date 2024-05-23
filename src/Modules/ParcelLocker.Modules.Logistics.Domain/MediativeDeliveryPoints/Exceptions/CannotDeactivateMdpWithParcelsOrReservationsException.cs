using ParcelLocker.Shared.Abstractions.Exceptions.Types;

namespace ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;

public class CannotDeactivateMdpWithParcelsOrReservationsException : CoreException
{
    public CannotDeactivateMdpWithParcelsOrReservationsException(string text) : base(text)
    {
    }
}