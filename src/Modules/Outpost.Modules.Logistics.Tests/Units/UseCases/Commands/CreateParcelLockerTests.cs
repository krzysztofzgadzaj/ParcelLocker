using FluentAssertions;
using Moq;
using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.CreateParcelLocker;
using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.DTO;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.ParcelLockers;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Repositories;
using OutPost.Shared.Abstractions.Localization;
using Xunit;

namespace Outpost.Modules.Logistics.Tests.Units.UseCases.Commands;

public class CreateParcelLockerTests
{
    private readonly Mock<IMdpRepository> _mdpRepositoryMock;
    private readonly Mock<ILocalizationService> _localizationServiceMock;
    private readonly Mock<IMdpCompanyRepository> _mdpCompanyRepositoryMock;
    private readonly CreateParcelLockerCommandHandler _handler;
    
    public CreateParcelLockerTests()
    {
        _mdpRepositoryMock = new Mock<IMdpRepository>();
        _localizationServiceMock = new Mock<ILocalizationService>();
        _mdpCompanyRepositoryMock = new Mock<IMdpCompanyRepository>();
        _handler = new CreateParcelLockerCommandHandler(
            _mdpRepositoryMock.Object, 
            _localizationServiceMock.Object,
            _mdpCompanyRepositoryMock.Object);
    }

    [Fact]
    public async Task Parcel_locker_is_created_for_correct_data_and_existing_mdp_company()
    {
        // Arrange
        var slotDtos = GenerateMandatorySlotDtos();
        var address = GenerateAddressDto();
        var serialCode = "serialCode";
        var mdpCompanyId = Guid.NewGuid();
        var mdpCompany = CreateMdpCompany(mdpCompanyId);

        _mdpCompanyRepositoryMock.Setup(x
                => x.GetById(It.Is<Guid>(y
                    => y == mdpCompanyId)))
            .ReturnsAsync(mdpCompany);

        _localizationServiceMock.Setup(x 
            => x.ValidateAddress(It.IsAny<string>()))
            .Returns(true);
        
        var command = new CreateParcelLockerCommand
        {
            Slots = slotDtos,
            Address = address,
            SerialCode = serialCode,
            MdpCompanyId = mdpCompanyId
        };

        // Act
        await _handler.SendAsync(command);

        // Assert
        _mdpRepositoryMock.Verify(x 
            => x.Create(It.Is<ParcelLocker>(y 
                => y.SerialCode.SerialNumber == serialCode 
                   && y.Status == MdpStatus.Inactive
                   && y.MdpCompany.Id == mdpCompanyId
                   && y.MdpType == MdpTypes.ParcelLocker)), 
            Times.Once);
    }
    
    [Fact]
    public async Task Parcel_locker_is_not_created_if_not_all_mandatory_slots_are_defined()
    {
        // Arrange
        var slotDtos = GenerateMandatorySlotDtos();
        slotDtos.RemoveAt(0);
        var address = GenerateAddressDto();
        var serialCode = "serialCode";
        var mdpCompanyId = Guid.NewGuid();
        var mdpCompany = CreateMdpCompany(mdpCompanyId);

        _mdpCompanyRepositoryMock.Setup(x
                => x.GetById(It.Is<Guid>(y
                    => y == mdpCompanyId)))
            .ReturnsAsync(mdpCompany);

        _localizationServiceMock.Setup(x 
                => x.ValidateAddress(It.IsAny<string>()))
            .Returns(true);
        
        var command = new CreateParcelLockerCommand
        {
            Slots = slotDtos,
            Address = address,
            SerialCode = serialCode,
            MdpCompanyId = mdpCompanyId
        };

        // Act
        var action = async () => await _handler.SendAsync(command);

        // Assert
        await action.Should().ThrowAsync<CannotCreateParcelLockerWithoutMandatorySlotsException>();
    }
    
    [Fact]
    public async Task Parcel_locker_is_not_created_if_address_is_not_valid()
    {
        // Arrange
        var slotDtos = GenerateMandatorySlotDtos();
        var address = GenerateAddressDto();
        var serialCode = "serialCode";
        var mdpCompanyId = Guid.NewGuid();
        var mdpCompany = CreateMdpCompany(mdpCompanyId);

        _mdpCompanyRepositoryMock.Setup(x
                => x.GetById(It.Is<Guid>(y
                    => y == mdpCompanyId)))
            .ReturnsAsync(mdpCompany);

        _localizationServiceMock.Setup(x 
                => x.ValidateAddress(It.IsAny<string>()))
            .Returns(false);
        
        var command = new CreateParcelLockerCommand
        {
            Slots = slotDtos,
            Address = address,
            SerialCode = serialCode,
            MdpCompanyId = mdpCompanyId
        };

        // Act
        var action = async () => await _handler.SendAsync(command);

        // Assert
        await action.Should().ThrowAsync<ArgumentException>();
    }
    
    [Fact]
    public async Task Parcel_locker_is_not_created_if_serial_code_is_not_delivered()
    {
        // Arrange
        var slotDtos = GenerateMandatorySlotDtos();
        var address = GenerateAddressDto();
        var serialCode = "";
        var mdpCompanyId = Guid.NewGuid();
        var mdpCompany = CreateMdpCompany(mdpCompanyId);

        _mdpCompanyRepositoryMock.Setup(x
                => x.GetById(It.Is<Guid>(y
                    => y == mdpCompanyId)))
            .ReturnsAsync(mdpCompany);

        _localizationServiceMock.Setup(x 
                => x.ValidateAddress(It.IsAny<string>()))
            .Returns(true);
        
        var command = new CreateParcelLockerCommand
        {
            Slots = slotDtos,
            Address = address,
            SerialCode = serialCode,
            MdpCompanyId = mdpCompanyId
        };

        // Act
        var action = async () => await _handler.SendAsync(command);

        // Assert
        await action.Should().ThrowAsync<IncorrectParcelLockerSerialNumberException>();
    }
    
    [Fact]
    public async Task Parcel_locker_is_not_created_if_mdp_company_does_not_exist()
    {
        // Arrange
        var slotDtos = GenerateMandatorySlotDtos();
        var address = GenerateAddressDto();
        var serialCode = "serialCode";
        var mdpCompanyId = Guid.NewGuid();

        _mdpCompanyRepositoryMock.Setup(x
                => x.GetById(It.Is<Guid>(y
                    => y == mdpCompanyId)))
            .ReturnsAsync((MdpCompany?) null);

        _localizationServiceMock.Setup(x 
                => x.ValidateAddress(It.IsAny<string>()))
            .Returns(true);
        
        var command = new CreateParcelLockerCommand
        {
            Slots = slotDtos,
            Address = address,
            SerialCode = serialCode,
            MdpCompanyId = mdpCompanyId
        };

        // Act
        var action = async () => await _handler.SendAsync(command);

        // Assert
        await action.Should().ThrowAsync<ApplicationException>();
    }
    
    [Fact]
    public async Task Parcel_locker_is_not_created_if_mdp_company_does_not_allow_creating_parcel_lockers()
    {
        // Arrange
        var slotDtos = GenerateMandatorySlotDtos();
        var address = GenerateAddressDto();
        var serialCode = "serialCode";
        var mdpCompanyId = Guid.NewGuid();
        var mdpCompany = CreateMdpCompany(mdpCompanyId, allowedMdpTypes: MdpTypes.ShoppingPoint);

        _mdpCompanyRepositoryMock.Setup(x
                => x.GetById(It.Is<Guid>(y
                    => y == mdpCompanyId)))
            .ReturnsAsync(mdpCompany);

        _localizationServiceMock.Setup(x 
                => x.ValidateAddress(It.IsAny<string>()))
            .Returns(true);
        
        var command = new CreateParcelLockerCommand
        {
            Slots = slotDtos,
            Address = address,
            SerialCode = serialCode,
            MdpCompanyId = mdpCompanyId
        };

        // Act
        var action = async () => await _handler.SendAsync(command);

        // Assert
        await action.Should().ThrowAsync<MdpCannotBeCreatedForCompanyException>();
    }

    private AddressDto GenerateAddressDto(string address = "address", string city = "city", string country = "country")
        => new (address, city, country);

    private List<ParcelLockerSlotDto> GenerateMandatorySlotDtos()
    {
        var slots = new List<ParcelLockerSlotDto>();

        for (var i = 0; i < 20; i++)
        {
            slots.Add(new ParcelLockerSlotDto(8, 38, 64));
        }
        
        for (var i = 0; i < 10; i++)
        {
            slots.Add(new ParcelLockerSlotDto(19, 38, 64));
        }
        
        for (var i = 0; i < 5; i++)
        {
            slots.Add(new ParcelLockerSlotDto(41, 28, 64));
        }

        return slots;
    }

    private MdpCompany CreateMdpCompany(Guid id, string name = "name", MdpTypes allowedMdpTypes = MdpTypes.All) =>
        new(id, name, allowedMdpTypes);
}
