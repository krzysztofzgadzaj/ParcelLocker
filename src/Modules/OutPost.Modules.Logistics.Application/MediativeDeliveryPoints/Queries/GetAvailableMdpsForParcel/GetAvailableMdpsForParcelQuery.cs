using OutPost.Shared.Abstractions.Queries;

namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Queries.GetAvailableMdpsForParcel;

public class GetAvailableMdpsForParcelQuery : IQuery<IEnumerable<MdpDto>>
{
    public double ParcelLengthInCm { get; init; } 
    public double ParcelWidthInCm { get; init; }
    public double ParcelHeightInCm { get; init; }
    public double ParcelWeightInKg { get; init; }
}