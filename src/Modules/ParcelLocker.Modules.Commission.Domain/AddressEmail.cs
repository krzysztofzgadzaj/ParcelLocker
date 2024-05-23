namespace ParcelLocker.Modules.Commission.Domain;

public class AddressEmail
{
    public AddressEmail(string email)
    {
        Email = email;
    }

    public string Email { get; }
}