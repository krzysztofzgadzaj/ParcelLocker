using OutPost.Shared.Abstractions.Exceptions.Types;

namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Exceptions;

public class ParcelLockerNotFoundException : NotFoundException
{
    public ParcelLockerNotFoundException(string text) : base(text)
    {
    }
}
