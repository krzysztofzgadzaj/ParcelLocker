using FluentAssertions;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.ParcelLockers;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared;
using OutPost.Modules.Logistics.Domain.Shared;
using Outpost.Modules.Logistics.Tests.Builders;
using Xunit;

namespace Outpost.Modules.Logistics.Tests.Units.Aggregates;

public class ParcelLockerAccessorAggregateTests
{
    [Fact]
    public void Parcel_locker_accessor_is_correctly_created_after_activation()
    {
        // Arrange & Act
        const MdpTypes mdpType = MdpTypes.ParcelLocker;
        const string serialCode = "Hello";
        const string address = "Very";
        const string mdpCompanyName = "Much";
        var parcelLockerAccessor = new ParcelLockerAccessorBuilder()
            .WithSerialCode(serialCode)
            .WithAddress(address)
            .WithMdpCompany(x 
                => x.WithName(mdpCompanyName))
            .Build();

        // Assert
        parcelLockerAccessor.MediativeDeliveryPoint.Should().BeOfType<ParcelLocker>();
        
        var parcelLocker = parcelLockerAccessor.MediativeDeliveryPoint as ParcelLocker;
        parcelLocker.MdpType.Should().Be(mdpType);
        parcelLocker.SerialCode.SerialNumber.Should().Be(serialCode);
        parcelLocker.MdpCompany.Name.Should().Be(mdpCompanyName);
        parcelLocker.Status.Should().Be(MdpStatus.Active);
        parcelLocker.Address.Location.Should().Be(address);
    }

    [Fact]
    public void Making_code_reservation_should_generate_code_and_reserve_slot()
    {
        // Arrange
        const string phoneNumber = "123123123";
        var parcelLockerAccessor = new ParcelLockerAccessorBuilder().Build();
        var parcel = new Parcel(new ParcelParameters(10, 10, 10, 10));
        var deadline = new Deadline(DateTime.UtcNow);
        
        // Act
        parcelLockerAccessor.ReserveStorageWithPhoneNumberSafeCodeAccess(parcel, phoneNumber, deadline);
        
        // Assert
        var parcelLocker = parcelLockerAccessor.MediativeDeliveryPoint as ParcelLocker;
        parcelLocker.Slots.Count(x => x.Status == ParcelLockerSlotStatus.Reserved).Should().Be(1);
        parcelLocker.Slots.First(x => x.Status == ParcelLockerSlotStatus.Reserved).AssignedParcelId.Should().Be(parcel.Id);

        parcelLockerAccessor.ParcelAccessRegistry.CodeAccessRegistryEntries.Count.Should().Be(1);
        parcelLockerAccessor.ParcelAccessRegistry.CodeAccessRegistryEntries.First().ParcelId.Should().Be(parcel.Id);
        parcelLockerAccessor.ParcelAccessRegistry.CodeAccessRegistryEntries.First().Deadline.DeadlineTime.Should().Be(deadline.DeadlineTime);
        parcelLockerAccessor.ParcelAccessRegistry.CodeAccessRegistryEntries.First().UnlockMethod.PhoneNumber.Should().Be(phoneNumber);
    }
    
    [Fact]
    public void Storing_parcel_using_valid_code_should_be_success()
    {
        // Arrange
        const string phoneNumber = "123123123";
        var parcelLockerAccessor = new ParcelLockerAccessorBuilder().Build();
        var parcel = new Parcel(new ParcelParameters(10, 10, 10, 10));
        var deadline = new Deadline(DateTime.UtcNow);
        parcelLockerAccessor.ReserveStorageWithPhoneNumberSafeCodeAccess(parcel, phoneNumber, deadline);
        var generatedCode = parcelLockerAccessor.ParcelAccessRegistry.CodeAccessRegistryEntries.First().UnlockMethod.Code;
        
        // Act
        parcelLockerAccessor.StoreParcelWithPhoneNumberSafeCodeAccess(generatedCode, phoneNumber);
        
        // Assert
        var parcelLocker = parcelLockerAccessor.MediativeDeliveryPoint as ParcelLocker;
        parcelLocker.Slots.Count(x => x.Status == ParcelLockerSlotStatus.Occupied).Should().Be(1);
        parcelLocker.Slots.First(x => x.Status == ParcelLockerSlotStatus.Occupied).AssignedParcelId.Should().Be(parcel.Id);
        parcelLockerAccessor.ParcelAccessRegistry.CodeAccessRegistryEntries.Count.Should().Be(0);
    }
}
