using ParcelLocker.Modules.Backoffice.Core.DTO;
using ParcelLocker.Modules.Backoffice.Core.Mappers;
using ParcelLocker.Modules.Backoffice.Core.Repositories.MdpCompany;
using ParcelLocker.Modules.Backoffice.Core.Validators;
using ParcelLocker.Shared.Abstractions.Messaging;

namespace ParcelLocker.Modules.Backoffice.Core.Services.MdpCompany;

public class MdpCompanyService : IMdpCompanyService
{
    private readonly IMdpCompanyRepository _mdpCompanyRepository;
    private readonly MdpCompanyValidator _mdpCompanyValidator;
    private readonly IMessageBroker _messageBroker;

    public MdpCompanyService(IMdpCompanyRepository mdpCompanyRepository, 
        MdpCompanyValidator mdpCompanyValidator, 
        IMessageBroker messageBroker)
    {
        _mdpCompanyRepository = mdpCompanyRepository;
        _mdpCompanyValidator = mdpCompanyValidator;
        _messageBroker = messageBroker;
    }

    public async Task CreateMdpCompany(MdpCompanyDto mdpCompanyDto)
    {
        _mdpCompanyValidator.ValidateDto(mdpCompanyDto);
        var mdpCompany = mdpCompanyDto.MapToMdpCompany();
        await _mdpCompanyRepository.Create(mdpCompany);

        await _messageBroker.PublishAsync(mdpCompany.MapToEvent());
    }

    public async Task<IEnumerable<MdpCompanyDto>> GetMdpCompanies()
    {
        var mdpCompanies = await _mdpCompanyRepository.Get();
        return mdpCompanies.Select(x => x.MapToDto());
    }
}
