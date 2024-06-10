using FluentAssertions;
using Moq;
using OutPost.Modules.Commission.Application.BackgroundProcessing;
using OutPost.Modules.Commission.Application.Commands;
using OutPost.Modules.Commission.Application.Dtos;
using OutPost.Modules.Commission.Application.Events.Internal;
using OutPost.Modules.Commission.Application.Exceptions;
using OutPost.Modules.Commission.Application.Repositories;
using OutPost.Modules.Commission.Domain;
using OutPost.Modules.Commission.Domain.DeliveryMethods;
using OutPost.Modules.Commission.Domain.Repositories;
using OutPost.Shared.Abstractions.Events;
using Xunit;
using DeliveryMethodType = OutPost.Modules.Commission.Application.Dtos.DeliveryMethodType;

namespace OutPost.Modules.Commission.Tests.Units.Handlers;

public class CreateCommissionTests
{
    private readonly Mock<ICommissionRepository> _commissionRepositoryMock;
    private readonly Mock<IOutpostConfigurationRepository> _outpostConfigurationRepositoryMock;
    private readonly Mock<IMdpRepository> _mdpRepositoryMock;
    private readonly Mock<IEventRepository> _eventRepositoryMock;
    private readonly Mock<IBackgroundValidator> _backgrounValidatorMock;
    private readonly CreateCommissionCommandHandler _handler;

    public CreateCommissionTests()
    {
        _commissionRepositoryMock = new Mock<ICommissionRepository>();
        _outpostConfigurationRepositoryMock = new Mock<IOutpostConfigurationRepository>();
        _mdpRepositoryMock = new Mock<IMdpRepository>();
        _eventRepositoryMock = new Mock<IEventRepository>();
        _backgrounValidatorMock = new Mock<IBackgroundValidator>();
        _handler = new CreateCommissionCommandHandler(
            _commissionRepositoryMock.Object,
            _outpostConfigurationRepositoryMock.Object,
            _mdpRepositoryMock.Object,
            _eventRepositoryMock.Object,
            _backgrounValidatorMock.Object);
        
        _outpostConfigurationRepositoryMock.Setup(x
                => x.GetOutpostMarkup())
            .ReturnsAsync(10);
        
        _mdpRepositoryMock.Setup(x
                => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(new Mdp(Guid.NewGuid(), 10));
    }

    [Fact]
    public async Task Commission_should_be_created_for_valid_command()
    {
        // Arrange
        _outpostConfigurationRepositoryMock.Setup(x
                => x.GetOutpostMarkup())
            .ReturnsAsync(10);

        var mdpId = Guid.NewGuid();
        _mdpRepositoryMock.Setup(x
                => x.GetByIdAsync(It.Is<Guid>(y => y == mdpId)))
            .ReturnsAsync(new Mdp(mdpId, 10));
        
        var startingPoint = CreateDirectDeliveryMethod("startingPoint");
        var deliveryPoint = CreateMdpDeliveryMethodDto(mdpId);
        var command = PrepareCreateCommissionCommand(parcelStartingPoint: startingPoint, parcelDeliveryPoint: deliveryPoint);
        
        // Act
        await _handler.SendAsync(command);
        
        // Assert
        _commissionRepositoryMock.Verify(x 
            => x.CreateAsync(
                It.Is<Domain.Commission>(commission
                    => commission.ParcelParameters.LengthInCm == command.ParcelParametersDto.Length
                    && commission.ParcelParameters.WidthInCm == command.ParcelParametersDto.Width
                    && commission.ParcelParameters.HeightInCm == command.ParcelParametersDto.Height
                    && commission.ParcelParameters.WeightInGrams == command.ParcelParametersDto.Weight
                    && commission.IsPaid == false
                    && commission.IsPaid == false
                    && commission.OutpostMarkup == 10
                    && commission.Status == CommissionStatus.UnderProcessing
                    && (commission.ParcelStartingPoint as DirectDeliveryMethod).Type == Domain.DeliveryMethods.DeliveryMethodType.Direct
                    && (commission.ParcelStartingPoint as DirectDeliveryMethod).Address.Location == startingPoint.Address!.Address
                    && (commission.ParcelDeliveryPoint as MdpDeliveryMethod).Type == Domain.DeliveryMethods.DeliveryMethodType.Mdp
                    && (commission.ParcelDeliveryPoint as MdpDeliveryMethod).Mdp.Id == deliveryPoint.MdpId)), 
            Times.Once());
    }

    [Fact]
    public async Task Exception_is_thrown_when_mdp_is_not_found()
    {
        // Arrange
        var mdpId = Guid.NewGuid();
        _mdpRepositoryMock.Setup(x
                => x.GetByIdAsync(It.Is<Guid>(y => y == mdpId)))
            .ReturnsAsync((Mdp?) null);

        var startingPoint = CreateMdpDeliveryMethodDto(mdpId);
        
        var command = PrepareCreateCommissionCommand(parcelStartingPoint: startingPoint);
        
        // Act
        var handleAction = async () => await _handler.SendAsync(command);
        
        // Assert
        await handleAction.Should().ThrowAsync<MdpNotFoundException>();
    }
    
    [Fact]
    public async Task Exception_is_thrown_when_outpost_markup_is_not_found()
    {
        // Arrange
        _outpostConfigurationRepositoryMock.Setup(x
                => x.GetOutpostMarkup())
            .ReturnsAsync((decimal?) null);
        
        var command = PrepareCreateCommissionCommand();
        
        // Act
        var handleAction = async () => await _handler.SendAsync(command);
        
        // Assert
        await handleAction.Should().ThrowAsync<OutpostMarkupNotDefinedException>();
    }
    
    [Fact]
    public async Task Integration_event_should_be_emitted_if_commission_was_created()
    {
        // TODO
    }
    
    [Fact]
    public async Task Event_should_be_persisted()
    {
        // Arrange
        var command = PrepareCreateCommissionCommand();
        
        // Act
        await _handler.SendAsync(command);
        
        // Assert
        _eventRepositoryMock.Verify(x 
            => x.StoreAsync(It.Is<IEnumerable<IEvent>>(events 
                => events.Count(y => y.GetType() == typeof(CommissionCreatedEvent)) == 1)), 
            Times.Once);
    }
    
    private static DeliveryMethodDto CreateDirectDeliveryMethod(string address = "address") 
        => new(DeliveryMethodType.Direct, null, new AddressDto(address));
    
    private static DeliveryMethodDto CreateMdpDeliveryMethodDto(Guid? id = null) 
        => new(DeliveryMethodType.Mdp, id ?? Guid.NewGuid(), null);
    
    private static ParcelParametersDto CreateParcelParametersDto(double height = 10, 
        double width = 10, 
        double length = 10,
        double weight = 10) 
        => new(height, width, length, weight);

    private static CreateCommissionCommand PrepareCreateCommissionCommand(
        ParcelParametersDto? parcelParameters = null,
        DeliveryMethodDto? parcelStartingPoint = null,
        DeliveryMethodDto? parcelDeliveryPoint = null)
    {
        var parcel = parcelParameters ?? CreateParcelParametersDto();
        var startingPoint = parcelStartingPoint ?? CreateDirectDeliveryMethod();
        var deliveryPoint = parcelDeliveryPoint ?? CreateMdpDeliveryMethodDto();
        
        return new CreateCommissionCommand(parcel, 
            startingPoint, 
            deliveryPoint);
    }
}
