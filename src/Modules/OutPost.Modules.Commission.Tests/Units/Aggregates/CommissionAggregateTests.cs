using FluentAssertions;
using OutPost.Modules.Commission.Domain;
using OutPost.Modules.Commission.Domain.DeliveryMethods;
using OutPost.Modules.Commission.Domain.Events;
using OutPost.Shared.Abstractions.Localization;
using Xunit;

namespace OutPost.Modules.Commission.Tests.Units.Aggregates;

public class CommissionAggregateTests
{
    [Fact]
    public void Commission_is_created_for_correct_data()
    {
        // Arrange
        var deliveryPoint = CreateDirectDeliveryMethod("location");
        var mdpId = Guid.NewGuid();
        var startingPoint = CreateMdpDeliveryMethod(mdpId, 10);
        var parcelParameters = CreateParcelParameters(20, 30, 40, 50);
        var outpostMarkup = 60;
        
        // Act
        var commission = CreateCommission(parcelParameters, startingPoint, deliveryPoint, 60);

        // Assert
        commission.ParcelParameters.HeightInCm.Should().Be(20);
        commission.ParcelParameters.WidthInCm.Should().Be(30);
        commission.ParcelParameters.LengthInCm.Should().Be(40);
        commission.ParcelParameters.WeightInGrams.Should().Be(50);
        commission.ParcelStartingPoint.Type.Should().Be(DeliveryMethodType.Mdp);
        var mdpMethod = commission.ParcelStartingPoint as MdpDeliveryMethod;
        mdpMethod!.Mdp.Id.Should().Be(mdpId);
        mdpMethod.Mdp.Markup.Should().Be(10);
        commission.ParcelDeliveryPoint.Type.Should().Be(DeliveryMethodType.Direct);
        var directMethod = commission.ParcelDeliveryPoint as DirectDeliveryMethod;
        directMethod!.Address.Location.Should().Be("location");
        commission.OutpostMarkup.Should().Be(outpostMarkup);
        commission.IsPaid.Should().Be(false);
        commission.IsValidated.Should().Be(false);
        commission.Status.Should().Be(CommissionStatus.UnderProcessing);
        var domainEvent = commission.GetEvents.FirstOrDefault();
        domainEvent.Should().BeOfType<CommissionCreatedDomainEvent>();
        var commissionCreatedEvent = domainEvent as CommissionCreatedDomainEvent;
        commissionCreatedEvent!.CommissionId.Should().Be(commission.Id);
    }

    [Fact]
    public void Commission_cost_is_calculated_properly()
    {
        // TODO
    }
    
    private static DirectDeliveryMethod CreateDirectDeliveryMethod(string address = "address") 
        => new(new Address(address));
    
    private static MdpDeliveryMethod CreateMdpDeliveryMethod(Guid? id = null, decimal markup = 10) 
        => new(new Mdp(id ?? Guid.NewGuid(), markup));
    
    private static ParcelParameters CreateParcelParameters(double height = 10, 
        double width = 10, 
        double length = 10,
        double weight = 10) 
            => new(height, width, length, weight);

    private static Domain.Commission CreateCommission(
        ParcelParameters? parcelParameters = null,
        DeliveryMethod? parcelStartingPoint = null,
        DeliveryMethod? parcelDeliveryPoint = null,
        decimal? outpostMarkup = null)
    {
        var parcel = parcelParameters ?? CreateParcelParameters();
        var startingPoint = parcelStartingPoint ?? CreateDirectDeliveryMethod();
        var deliveryPoint = parcelDeliveryPoint ?? CreateMdpDeliveryMethod();
        var outpostMarkupValue = outpostMarkup ?? 10;
        
        return Domain.Commission.CreateCommission(parcel, 
            startingPoint, 
            deliveryPoint,
            outpostMarkupValue);
    }
}
