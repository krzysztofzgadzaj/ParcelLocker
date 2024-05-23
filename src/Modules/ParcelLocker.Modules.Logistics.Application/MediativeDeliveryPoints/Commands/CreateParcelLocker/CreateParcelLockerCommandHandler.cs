using ParcelLocker.Modules.Logistics.Application.MediativeDeliveryPoints.DTO;
using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints;
using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.ParcelLocker;
using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Repositories;
using ParcelLocker.Shared.Abstractions.Commands;
using ParcelLocker.Shared.Abstractions.Localization;

namespace ParcelLocker.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.CreateParcelLocker;

public class CreateParcelLockerCommandHandler : ICommandHandler<CreateParcelLockerCommand>
{
    private readonly IMdpRepository _mdpRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IMdpCompanyRepository _mdpCompanyRepository;

    public CreateParcelLockerCommandHandler(IMdpRepository mdpRepository, ILocalizationService localizationService, IMdpCompanyRepository mdpCompanyRepository)
    {
        _mdpRepository = mdpRepository;
        _localizationService = localizationService;
        _mdpCompanyRepository = mdpCompanyRepository;
    }

    public async Task SendAsync(CreateParcelLockerCommand command)
    {
        var slots = CreateSlots(command.Slots);
        var serialCode = new ParcelLockerSerialCode(command.SerialCode);
        var address = CreateAddress(command.Address);
        var mdpCompany = await _mdpCompanyRepository.GetById(new MdpCompanyId(command.MdpCompanyId));

        if (mdpCompany is null)
        {
            throw new ApplicationException();
        }
        
        var parcelLocker = new Logistics.Domain.MediativeDeliveryPoints.ParcelLocker.ParcelLocker(slots, serialCode, address, mdpCompany);
        await _mdpRepository.Create(parcelLocker);
        
        // TODO - Publish event, domain or integration using UnitOfWork
    }

    private static List<ParcelLockerSlot> CreateSlots(IEnumerable<ParcelLockerSlotDto> parcelLockerSlotDtos)
        => parcelLockerSlotDtos
            .Select(x => new ParcelLockerSlot(x.LengthInCm, x.HeightInCm, x.WidthInCm))
            .ToList();

    private Address CreateAddress(AddressDto addressDto)
    {
        // TODO - Fix after decision about localization
        if (!_localizationService.ValidateAddress(addressDto.Address))
        {
            throw new ArgumentException();
        }

        return new Address(addressDto.Address);
    }
}
