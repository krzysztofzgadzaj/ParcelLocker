using ParcelLocker.Shared.Abstractions.Localization;

namespace ParcelLocker.Shared.Infrastructure.Localization;

public class LocalizationService : ILocalizationService
{
    public GeographicalCoordinates MapAddressToCoordinates(Address address)
    {
        throw new NotImplementedException();
    }

    public bool ValidateAddress(string address)
    {
        return true;
    }
}