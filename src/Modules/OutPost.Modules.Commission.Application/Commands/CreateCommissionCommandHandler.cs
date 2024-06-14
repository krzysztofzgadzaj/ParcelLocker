using OutPost.Modules.Commission.Application.BackgroundProcessing;
using OutPost.Modules.Commission.Application.Dtos;
using OutPost.Modules.Commission.Application.Events;
using OutPost.Modules.Commission.Application.Exceptions;
using OutPost.Modules.Commission.Application.Repositories;
using OutPost.Modules.Commission.Domain;
using OutPost.Modules.Commission.Domain.DeliveryMethods;
using OutPost.Modules.Commission.Domain.Repositories;
using OutPost.Shared.Abstractions.Commands;
using OutPost.Shared.Abstractions.Localization;
using DeliveryMethodType = OutPost.Modules.Commission.Application.Dtos.DeliveryMethodType;

namespace OutPost.Modules.Commission.Application.Commands;

public class CreateCommissionCommandHandler : ICommandHandler<CreateCommissionCommand>
{
    private readonly ICommissionRepository _commissionRepository;
    private readonly IOutpostConfigurationRepository _outpostConfigurationRepository;
    private readonly IMdpRepository _mdpRepository;
    private readonly IEventRepository _eventRepository;

    public CreateCommissionCommandHandler(ICommissionRepository commissionRepository, 
        IOutpostConfigurationRepository outpostConfigurationRepository, 
        IMdpRepository mdpRepository, 
        IEventRepository eventRepository)
    {
        _commissionRepository = commissionRepository;
        _outpostConfigurationRepository = outpostConfigurationRepository;
        _mdpRepository = mdpRepository;
        _eventRepository = eventRepository;
    }

    public async Task SendAsync(CreateCommissionCommand command)
    {
        var (parcelParametersDto, parcelStartingPointDto, parcelDeliveryPointDto) = command;
        var parcelParameters = new ParcelParameters(parcelParametersDto.Height, 
            parcelParametersDto.Width,
            parcelParametersDto.Length, 
            parcelParametersDto.Weight);

        var parcelStartingPoint = await CreateDeliveryMethod(parcelStartingPointDto);
        var parcelDeliveryPoint = await CreateDeliveryMethod(parcelDeliveryPointDto);

        var outpostMarkup = await _outpostConfigurationRepository.GetOutpostMarkup();

        if (outpostMarkup is null)
        {
            throw new OutpostMarkupNotDefinedException("siema");
        }

        var commission = Domain.Commission.CreateCommission(parcelParameters, parcelStartingPoint, parcelDeliveryPoint, outpostMarkup.Value);
        await _commissionRepository.CreateAsync(commission);
        await _eventRepository.StoreAsync(EventMapper.Map(commission.GetEvents));
    }

    private async Task<DeliveryMethod> CreateDeliveryMethod(DeliveryMethodDto deliveryMethodDto)
    {
        if (deliveryMethodDto.DeliveryMethodType == DeliveryMethodType.Direct)
        {
            return new DirectDeliveryMethod(new Address(deliveryMethodDto.Address!.Address));
        }

        if (deliveryMethodDto.DeliveryMethodType == DeliveryMethodType.Mdp)
        {
            var mdp = await _mdpRepository.GetByIdAsync(deliveryMethodDto.MdpId!.Value);

            if (mdp is null)
            {
                throw new MdpNotFoundException("elo");
            }

            return new MdpDeliveryMethod(mdp);
        }

        throw new ApplicationException();
    }
}
