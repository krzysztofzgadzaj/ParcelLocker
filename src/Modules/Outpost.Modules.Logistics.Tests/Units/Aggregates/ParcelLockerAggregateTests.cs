using FluentAssertions;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;
using Outpost.Modules.Logistics.Tests.Builders;
using Xunit;

namespace Outpost.Modules.Logistics.Tests.Units.Aggregates;

public class ParcelLockerAggregateTests
{
    [Fact]
    public void Created_parcel_locker_is_disabled()
    {
        // Arrange
        var parcelLocker = new ParcelLockerBuilder().Build();

        // Act & Assert
        parcelLocker.Status.Should().Be(MdpStatus.Inactive);
    }
    
    [Fact]
    public void Mdp_company_needs_to_accept_certain_mdp_type()
    {
        // Arrange
        var parcelLockerCreationAction = () => new ParcelLockerBuilder()
            .WithMdpCompany(x => x.WithAllowedMdpTypes(MdpTypes.ShoppingPoint))
            .Build();

        // Act & Assert
        parcelLockerCreationAction.Should().Throw<MdpCannotBeCreatedForCompanyException>();
    }

    [Fact]
    public void Parcel_locker_should_be_activated()
    {
        // Arrange
        var parcelLocker = new ParcelLockerBuilder().Build();
        
        // Act
        parcelLocker.Activate();
        
        // Assert
        parcelLocker.Status.Should().Be(MdpStatus.Active);
    }

    [Fact]
    public void Inactive_parcel_locker_cannot_store_parcel()
    {
        // Arrange
        var parcelLocker = new ParcelLockerBuilder().Build();
        var parcel = new Parcel(new ParcelParameters(10, 10, 10, 10));
        
        // Act
        var canStoreParcel = parcelLocker.CanStoreParcel(parcel.ParcelParameters);
        
        // Assert
        canStoreParcel.Should().Be(false);
    }
    
    [Theory]
    [InlineData(10, 10, 10, true)]
    [InlineData(100, 10, 10, false)]
    [InlineData(10, 100, 10, false)]
    [InlineData(10, 10, 100, false)]
    public void Active_parcel_locker_can_store_parcel_with_matching_size(double parcelLength, 
        double parcelWidth, 
        double parcelHeight, 
        bool result)
    {
        // Arrange
        var parcelLocker = new ParcelLockerBuilder().Build();
        parcelLocker.Activate();
        var parcel = new Parcel(new ParcelParameters(parcelLength, parcelWidth, parcelHeight, 10));
        
        // Act
        var canStoreParcel = parcelLocker.CanStoreParcel(parcel.ParcelParameters);
        
        // Assert
        canStoreParcel.Should().Be(result);
    }
    
    [Fact]
    public void Active_parcel_locker_cannot_store_parcel_if_has_not_available_slot()
    {
        // Arrange
        var parcelLocker = new ParcelLockerBuilder().Build();
        parcelLocker.Activate();
        
        foreach (var slot in parcelLocker.Slots)
        {
            parcelLocker.ReserveSlotForParcel(
                new Parcel
                    (new ParcelParameters(
                        slot.LengthInCm, 
                        slot.WidthInCm, 
                        slot.HeightInCm, 
                        10)));
        }
        
        var parcel = new Parcel(new ParcelParameters(10, 10, 10, 10));
        
        // Act
        var canStoreParcel = parcelLocker.CanStoreParcel(parcel.ParcelParameters);
        
        // Assert
        canStoreParcel.Should().Be(false);
    }

    [Fact]
    public void Parcel_can_be_stored_when_slot_was_previously_reserved()
    {
        // Arrange
        var parcelLocker = new ParcelLockerBuilder().Build();
        parcelLocker.Activate();
        var parcel = new Parcel(new ParcelParameters(10, 10, 10, 10));
        parcelLocker.ReserveSlotForParcel(parcel);
        
        // Act
        parcelLocker.StoreParcel(parcel);
        
        // Assert
        parcelLocker.Slots.FirstOrDefault(x => x.AssignedParcelId == parcel.Id).Should().NotBe(null);
    }
    
    [Fact]
    public void Parcel_cannot_be_stored_when_slot_was_not_previously_reserved()
    {
        // Arrange
        var parcelLocker = new ParcelLockerBuilder().Build();
        parcelLocker.Activate();
        var parcel = new Parcel(new ParcelParameters(10, 10, 10, 10));
        
        // Act
        var action = () => parcelLocker.StoreParcel(parcel);
        
        // Assert
        action.Should().Throw<ApplicationException>();
    }
    
    [Fact]
    public void Parcel_locker_can_be_deactivated_when_no_slot_is_occupied_or_reserved()
    {
        // Arrange
        var parcelLocker = new ParcelLockerBuilder().Build();
        parcelLocker.Activate();
        
        // Act
        parcelLocker.Deactivate();
        
        // Assert
        parcelLocker.Status.Should().Be(MdpStatus.Inactive);
    }
    
    [Fact]
    public void Parcel_locker_cannot_be_deactivated_when_any_slot_is_reserved()
    {
        // Arrange
        var parcelLocker = new ParcelLockerBuilder().Build();
        parcelLocker.Activate();
        var parcel = new Parcel(new ParcelParameters(10, 10, 10, 10));
        parcelLocker.ReserveSlotForParcel(parcel);
        
        // Act
        var action = () => parcelLocker.Deactivate();
        
        // Assert
        action.Should().Throw<CannotDeactivateMdpWithParcelsOrReservationsException>();
    }
    
    [Fact]
    public void Parcel_locker_cannot_be_deactivated_when_any_slot_is_occupied()
    {
        // Arrange
        var parcelLocker = new ParcelLockerBuilder().Build();
        parcelLocker.Activate();
        var parcel = new Parcel(new ParcelParameters(10, 10, 10, 10));
        parcelLocker.ReserveSlotForParcel(parcel);
        parcelLocker.StoreParcel(parcel);
        
        // Act
        var action = () => parcelLocker.Deactivate();
        
        // Assert
        action.Should().Throw<CannotDeactivateMdpWithParcelsOrReservationsException>();
    }
}
