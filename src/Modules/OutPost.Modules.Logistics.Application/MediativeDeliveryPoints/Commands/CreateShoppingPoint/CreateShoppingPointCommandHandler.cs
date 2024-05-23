using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.DTO;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Repositories;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.ShoppingPoint;
using OutPost.Shared.Abstractions.Commands;
using OutPost.Shared.Abstractions.Localization;

namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.CreateShoppingPoint;

public class CreateShoppingPointCommandHandler : ICommandHandler<CreateShoppingPointCommand>
{
    private readonly IMdpRepository _mdpRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IMdpCompanyRepository _mdpCompanyRepository;

    public CreateShoppingPointCommandHandler(IMdpRepository mdpRepository, ILocalizationService localizationService, IMdpCompanyRepository mdpCompanyRepository)
    {
        _mdpRepository = mdpRepository;
        _localizationService = localizationService;
        _mdpCompanyRepository = mdpCompanyRepository;
    }

    public async Task SendAsync(CreateShoppingPointCommand command)
    {
        var (maxParcelLengthInCm, maxParcelWidthInCm, maxParcelHeightInCm, maxParcelWeightInKg, capacityInCm) = command.ShoppingPointStorageDto;
        var storage = new StorageCapacity(maxParcelLengthInCm, maxParcelHeightInCm, maxParcelWidthInCm, maxParcelWeightInKg, capacityInCm);
        var naturalIdentifier = new ShoppingPointIdentifier(command.ShoppingPointIdentifier);
        var address = CreateAddress(command.Address);
        var mdpCompany = await _mdpCompanyRepository.GetById(command.MdpCompanyId);

        if (mdpCompany is null)
        {
            throw new ApplicationException();
        }
        
        var parcelLocker = new ShoppingPoint(mdpCompany, address, naturalIdentifier, storage);
        await _mdpRepository.Create(parcelLocker);
        
        // TODO - Publish event, domain or integration using UnitOfWork
    }

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
