using FluentAssertions;
using Moq;
using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.ActivateMdp;
using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Exceptions;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Repositories;
using Outpost.Modules.Logistics.Tests.Builders;
using Xunit;

namespace Outpost.Modules.Logistics.Tests.Units.UseCases;

public class ActivateMdpTests
{
    private readonly Mock<IMdpRepository> _mdpRepositoryMock;
    private readonly ActivateMdpCommandHandler _handler;
    
    public ActivateMdpTests()
    {
        _mdpRepositoryMock = new Mock<IMdpRepository>();
        _handler = new ActivateMdpCommandHandler(_mdpRepositoryMock.Object);
    }

    [Fact]
    async Task Parcel_locker_is_activated()
    {
        // Arrange
        var parcelLocker = new ParcelLockerBuilder().Build();
        _mdpRepositoryMock.Setup(x
                => x.GetById(It.Is<Guid>(y
                    => y == parcelLocker.Id)))
            .ReturnsAsync(parcelLocker);

        var command = new ActivateMdpCommand(parcelLocker.Id);

        // Act
        await _handler.SendAsync(command);

        // Assert
        parcelLocker.Status.Should().Be(MdpStatus.Active);
    }
    
    [Fact]
    async Task Exception_is_thrown_when_parcel_locker_does_not_exist()
    {
        // Arrange
        var parcelLocker = new ParcelLockerBuilder().Build();
        _mdpRepositoryMock.Setup(x
                => x.GetById(It.Is<Guid>(y
                    => y == parcelLocker.Id)))
            .ReturnsAsync((MediativeDeliveryPoint?) null);

        var command = new ActivateMdpCommand(parcelLocker.Id);

        // Act
        var action = async () => await _handler.SendAsync(command);

        // Assert
        await action.Should().ThrowAsync<MediativeDeliveryPointNotFoundException>();
    }
}
