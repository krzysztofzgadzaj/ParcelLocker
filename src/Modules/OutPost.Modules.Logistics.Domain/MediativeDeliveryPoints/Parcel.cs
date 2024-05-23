namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints;

public class Parcel
{
    public Parcel(ParcelParameters parcelParameters)
    {
        ParcelParameters = parcelParameters;

        Id = new ParcelId(Guid.NewGuid());
    }

    public ParcelId Id { get; init; }
    public ParcelParameters ParcelParameters { get; init; }
}
