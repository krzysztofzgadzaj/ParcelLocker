using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.DTO;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.ParcelLockers;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointDrafts.ParcelLockers;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointDrafts.Repositories;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared.Repositories;
using OutPost.Shared.Abstractions.Commands;
using OutPost.Shared.Abstractions.Localization;

namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.CreateParcelLocker;

public class CreateDraftParcelLockerCommandHandler : ICommandHandler<CreateDraftParcelLockerCommand>
{
    private readonly IMdpDraftRepository _mdpDraftRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IMdpCompanyRepository _mdpCompanyRepository;

    public CreateDraftParcelLockerCommandHandler(IMdpDraftRepository mdpDraftRepository, ILocalizationService localizationService, IMdpCompanyRepository mdpCompanyRepository)
    {
        _mdpDraftRepository = mdpDraftRepository;
        _localizationService = localizationService;
        _mdpCompanyRepository = mdpCompanyRepository;
    }

    public async Task SendAsync(CreateDraftParcelLockerCommand command)
    {
        var slots = CreateSlots(command.Slots);
        var serialCode = new ParcelLockerSerialCode(command.SerialCode);
        var address = CreateAddress(command.Address);
        var mdpCompany = await _mdpCompanyRepository.GetById(command.MdpCompanyId);

        if (mdpCompany is null)
        {
            throw new ApplicationException();
        }
        
        var parcelLocker = new ParcelLockerDraft(slots, serialCode, address, mdpCompany);
        await _mdpDraftRepository.Create(parcelLocker);
        
        // TODO - Publish event, domain or integration using UnitOfWork
    }

    private static List<DraftParcelLockerSlot> CreateSlots(IEnumerable<ParcelLockerSlotDto> parcelLockerSlotDtos)
        => parcelLockerSlotDtos
            .Select(x => new DraftParcelLockerSlot(
                new ParcelLockerSlotSizeParameters(
                x.LengthInCm, 
                x.WidthInCm, 
                x.HeightInCm)))
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
