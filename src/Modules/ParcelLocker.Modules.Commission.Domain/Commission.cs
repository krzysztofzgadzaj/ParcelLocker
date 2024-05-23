using ParcelLocker.Modules.Commission.Domain.ParcelHandover;
using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Commission.Domain;

public class Commission : AggregateRoot<CommissionId>
{
    public Commission(ParcelParameters parcelParameters, Handover bringHandover, Handover deliveryHandover, AddressEmail addressEmail, PhoneNumber senderPhoneNumber, PhoneNumber? receiverPhoneNumber)
    {
        ParcelParameters = parcelParameters;
        BringHandover = bringHandover;
        DeliveryHandover = deliveryHandover;
        AddressEmail = addressEmail;
        SenderPhoneNumber = senderPhoneNumber;
        ReceiverPhoneNumber = receiverPhoneNumber;
    }

    public ParcelParameters ParcelParameters { get; }
    public Handover BringHandover { get; }
    public Handover DeliveryHandover { get; }
    public AddressEmail AddressEmail { get; }
    public PhoneNumber SenderPhoneNumber { get; }
    public PhoneNumber? ReceiverPhoneNumber { get; } 
}
