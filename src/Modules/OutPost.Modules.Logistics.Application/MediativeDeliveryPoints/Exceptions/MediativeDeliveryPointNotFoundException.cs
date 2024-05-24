using OutPost.Shared.Abstractions.Exceptions.Types;

namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Exceptions;

public class MediativeDeliveryPointNotFoundException : NotFoundException
{
    public MediativeDeliveryPointNotFoundException(string text) : base(text)
    {
    }
}
