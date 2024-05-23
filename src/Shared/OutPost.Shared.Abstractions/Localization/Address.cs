namespace OutPost.Shared.Abstractions.Localization;

public class Address
{
    public Address(string location)
    {
        Location = location;
    }

    public string Location { get; init; }
}
