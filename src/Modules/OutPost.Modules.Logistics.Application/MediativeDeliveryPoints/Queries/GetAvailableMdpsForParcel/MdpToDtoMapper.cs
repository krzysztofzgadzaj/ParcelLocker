using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints;

namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Queries.GetAvailableMdpsForParcel;

public static class MdpToDtoMapper
{
    public static MdpDto Map(this MediativeDeliveryPoint mediativeDeliveryPoint)
        => new()
        {
            Id = mediativeDeliveryPoint.Id,
        };
}

public class MdpDto
{
    public Guid Id { get; set; }
}
