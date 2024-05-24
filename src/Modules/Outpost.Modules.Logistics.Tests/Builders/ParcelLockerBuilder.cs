using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.ParcelLockers;
using OutPost.Shared.Abstractions.Localization;

namespace Outpost.Modules.Logistics.Tests.Builders;

public class ParcelLockerBuilder
{
    private string? _serialCode;
    private string? _address;
    private MdpCompanyBuilder _mdpCompanyBuilder = new();
    private List<ParcelLockerSlot> _slots = new ();

    public ParcelLockerBuilder WithSlot(double length, double height, double width, ParcelLockerSlotStatus status)
    {
        _slots.Add(new ParcelLockerSlot(length, height, width));
        return this;
    }

    public ParcelLockerBuilder WithSerialCode(string code)
    {
        _serialCode = code;
        return this;
    }
    
    public ParcelLockerBuilder WithAddress(string address)
    {
        _address = address;
        return this;
    }

    public ParcelLockerBuilder WithMdpCompany(Func<MdpCompanyBuilder, MdpCompanyBuilder> createMdpCompanyAction)
    {
        createMdpCompanyAction(_mdpCompanyBuilder);
        return this;
    }

    public ParcelLocker Build()
    {
        var serialCode = new ParcelLockerSerialCode(_serialCode ?? "serialCode");
        var address = new Address(_address ?? "address");
        var slots = CreateMandatorySlots();
        var mdpCompany = _mdpCompanyBuilder.Build();
        var parcelLocker = new ParcelLocker(slots, serialCode, address, mdpCompany);

        return parcelLocker;
    }

    private IEnumerable<ParcelLockerSlot> CreateMandatorySlots()
    {
        var slots = new List<ParcelLockerSlot>();

        for (var i = 0; i < 20; i++)
        {
            slots.Add(new ParcelLockerSlot(8, 38, 64));
        }
        
        for (var i = 0; i < 10; i++)
        {
            slots.Add(new ParcelLockerSlot(19, 38, 64));
        }
        
        for (var i = 0; i < 5; i++)
        {
            slots.Add(new ParcelLockerSlot(41, 28, 64));
        }

        return slots;
    }
}