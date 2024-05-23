using OutPost.Modules.Backoffice.Core.DTO;
using OutPost.Modules.Backoffice.Core.Repositories.MdpCompany;
using OutPost.Modules.Backoffice.Core.Validators;
using OutPost.Modules.Backoffice.Core.Mappers;
using OutPost.Shared.Abstractions.Messaging;

namespace OutPost.Modules.Backoffice.Core.Services.MdpCompany;

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
