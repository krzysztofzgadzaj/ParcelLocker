using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors;

namespace Outpost.Modules.Logistics.Tests.Builders;

public class ParcelLockerAccessorBuilder
{
    private string? _address;
    private string? _serialCode;
    private Func<MdpCompanyBuilder, MdpCompanyBuilder>? _mdpCompanyBuilderExpression;
    
    public ParcelLockerAccessorBuilder WithAddress(string address)
    {
        _address = address;
        return this;
    }
    
    public ParcelLockerAccessorBuilder WithMdpCompany(Func<MdpCompanyBuilder, MdpCompanyBuilder> builderExpression)
    {
        _mdpCompanyBuilderExpression = builderExpression;
        
        return this;
    }
    
    public ParcelLockerAccessorBuilder WithSerialCode(string serialCode)
    {
        _serialCode = serialCode;
        return this;
    }
    
    public MediativeDeliveryPointAccessor Build()
    {

        var parcelLocker = new ParcelLockerDraftBuilder()
            .WithSerialCode(_serialCode ?? "serialCode")
            .WithAddress(_address ?? "address")
            .WithMdpCompany(_mdpCompanyBuilderExpression)
            .Build();
        
        var parcelLockerAccessor = parcelLocker.Activate();

        return parcelLockerAccessor;
    }
}
