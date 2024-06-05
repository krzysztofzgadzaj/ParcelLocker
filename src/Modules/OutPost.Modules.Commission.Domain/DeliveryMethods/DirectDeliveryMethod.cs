using OutPost.Shared.Abstractions.Localization;

namespace OutPost.Modules.Commission.Domain.DeliveryMethods;

public class DirectDeliveryMethod : DeliveryMethod
{
    public DirectDeliveryMethod(Address address)
    {
        Address = address;
    }

    public override DeliveryMethodType Type => DeliveryMethodType.Direct;
    public Address Address { get; }
}