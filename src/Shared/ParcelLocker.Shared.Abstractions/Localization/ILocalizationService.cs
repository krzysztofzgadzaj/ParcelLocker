namespace ParcelLocker.Shared.Abstractions.Localization;

public interface ILocalizationService
{
    GeographicalCoordinates MapAddressToCoordinates(Address address);
    bool ValidateAddress(string country);
}
