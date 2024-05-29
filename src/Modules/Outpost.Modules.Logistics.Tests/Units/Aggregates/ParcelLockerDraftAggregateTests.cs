using FluentAssertions;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Exceptions;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.ParcelLockers;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared;
using Outpost.Modules.Logistics.Tests.Builders;
using Xunit;

namespace Outpost.Modules.Logistics.Tests.Units.Aggregates;

public class ParcelLockerDraftAggregateTests
{
    [Fact]
    public void Valid_parcel_locker_draft_is_created()
    {
        // Arrange & Act
        var parcelLockerDraft = new ParcelLockerDraftBuilder()
            .WithAddress("Very")
            .WithMdpCompany(x => 
                x.WithName("nice"))
            .WithSerialCode("to")
            .Build();
        
        // Assert
        parcelLockerDraft.Address.Location.Should().Be("Very");
        parcelLockerDraft.MdpCompany.Name.Should().Be("nice");
        parcelLockerDraft.SerialCode.SerialNumber.Should().Be("to");
        parcelLockerDraft.Status.Should().Be(MdpStatus.Inactive);
    }

    [Fact]
    public void Mdp_company_needs_to_accept_certain_mdp_type()
    {
        // Arrange
        var parcelLockerCreationAction = () => new ParcelLockerDraftBuilder()
            .WithMdpCompany(x => x.WithAllowedMdpTypes(MdpTypes.ShoppingPoint))
            .Build();

        // Act & Assert
        parcelLockerCreationAction.Should().Throw<MdpCannotBeCreatedForCompanyException>();
    }
    
    [Fact]
    public void Serial_code_cannot_be_empty()
    {
        // Arrange
        var parcelLockerBuilder = () => new ParcelLockerDraftBuilder()
            .WithSerialCode("")
            .Build();

        // Act & Assert
        parcelLockerBuilder.Should().Throw<IncorrectParcelLockerSerialNumberException>();
    }
    
    [Fact]
    public void Parcel_locker_is_not_created_without_mandatory_slots()
    {
        // Arrange
        var parcelLockerBuilder = () => new ParcelLockerDraftBuilder()
            .WithoutMandatorySlots()
            .Build();

        // Act & Assert
        parcelLockerBuilder.Should().Throw<CannotCreateParcelLockerWithoutMandatorySlotsException>();
    }

    [Fact]
    public void Activated_parcel_locker_draft_should_create_valid_parcel_locker_accessor()
    {
        // Arrange
        var parcelLockerDraft = new ParcelLockerDraftBuilder().Build();

        // Act
        var accessor = parcelLockerDraft.Activate();

        // Assert
        accessor.Id.Should().Be(parcelLockerDraft.Id);
        accessor.MediativeDeliveryPoint.Should().BeOfType<ParcelLocker>();
        
        var parcelLocker = accessor.MediativeDeliveryPoint as ParcelLocker;
        parcelLocker.MdpType.Should().Be(parcelLockerDraft.MdpType);
        parcelLocker.SerialCode.SerialNumber.Should().Be(parcelLockerDraft.SerialCode.SerialNumber);
        parcelLocker.MdpCompany.Id.Should().Be(parcelLockerDraft.MdpCompany.Id);
        parcelLocker.Status.Should().Be(MdpStatus.Active);
        parcelLocker.Address.Location.Should().Be(parcelLockerDraft.Address.Location);
    }
}
