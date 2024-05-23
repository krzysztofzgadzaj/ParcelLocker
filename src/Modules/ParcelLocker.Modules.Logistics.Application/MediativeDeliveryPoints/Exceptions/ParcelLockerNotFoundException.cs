using ParcelLocker.Shared.Abstractions.Exceptions.Types;

namespace ParcelLocker.Modules.Logistics.Application.MediativeDeliveryPoints.Exceptions;

public class ParcelLockerNotFoundException : NotFoundException
{
    public ParcelLockerNotFoundException(string text) : base(text)
    {
    }
}
