namespace OutPost.Modules.Logistics.Domain.Shared;

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
