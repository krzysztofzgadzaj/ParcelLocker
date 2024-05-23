namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints;

public class Parcel
{
    public Parcel(ParcelParameters parcelParameters)
    {
        ParcelParameters = parcelParameters;

        Id = Guid.NewGuid();
    }

    public Guid Id { get; init; }
    public ParcelParameters ParcelParameters { get; init; }
}
