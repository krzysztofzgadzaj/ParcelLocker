namespace OutPost.Modules.Commission.Domain;

public class PhoneNumber
{
    public PhoneNumber(string number)
    {
        Number = number;
    }

    public string Number { get; }
}