using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointDrafts.ParcelLockers;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared;
using OutPost.Shared.Abstractions.Localization;

namespace Outpost.Modules.Logistics.Tests.Builders;

public class ParcelLockerDraftBuilder
{
    private string? _address;
    private string? _serialCode;
    private bool _withMandatorySlots = true;
    private MdpCompanyBuilder _mdpCompanyBuilder = new();
    private List<DraftParcelLockerSlot> _slots = new ();

    public ParcelLockerDraftBuilder WithSlot(double length, double height, double width)
    {
        _slots.Add(new DraftParcelLockerSlot(new ParcelLockerSlotSizeParameters(length, height, width)));
        return this;
    }
    
    public ParcelLockerDraftBuilder WithoutMandatorySlots()
    {
        _withMandatorySlots = false;
        return this;
    }
    
    public ParcelLockerDraftBuilder WithAddress(string address)
    {
        _address = address;
        return this;
    }
    
    public ParcelLockerDraftBuilder WithMdpCompany(Func<MdpCompanyBuilder, MdpCompanyBuilder>? action = null)
    {
        if (action is not null)
        {
            _mdpCompanyBuilder = action(_mdpCompanyBuilder);   
        }
        
        return this;
    }
    
    public ParcelLockerDraftBuilder WithSerialCode(string serialCode)
    {
        _serialCode = serialCode;
        return this;
    }
    
    public ParcelLockerDraft Build()
    {
        if (_withMandatorySlots)
        {
            var slots = CreateMandatorySlots();
            _slots.AddRange(slots);
        }
        
        var serialCode = new ParcelLockerSerialCode(_serialCode ?? "serialCode");
        var address = new Address(_address ?? "address");
        var mdpCompany = _mdpCompanyBuilder.Build();
        var parcelLocker = new ParcelLockerDraft(_slots, serialCode, address, mdpCompany);

        return parcelLocker;
    }
    
    private List<DraftParcelLockerSlot> CreateMandatorySlots()
    {
        var slots = new List<DraftParcelLockerSlot>();

        for (var i = 0; i < 20; i++)
        {
            slots.Add(new DraftParcelLockerSlot(new ParcelLockerSlotSizeParameters(8, 38, 64)));
        }

        for (var i = 0; i < 10; i++)
        {
            slots.Add(new DraftParcelLockerSlot(new ParcelLockerSlotSizeParameters(19, 38, 64)));
        }

        for (var i = 0; i < 5; i++)
        {
            slots.Add(new DraftParcelLockerSlot(new ParcelLockerSlotSizeParameters(41, 28, 64)));
        }

        return slots;
    }
}
