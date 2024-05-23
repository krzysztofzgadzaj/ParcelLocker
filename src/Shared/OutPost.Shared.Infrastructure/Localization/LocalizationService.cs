using OutPost.Shared.Abstractions.Localization;

namespace OutPost.Shared.Infrastructure.Localization;

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