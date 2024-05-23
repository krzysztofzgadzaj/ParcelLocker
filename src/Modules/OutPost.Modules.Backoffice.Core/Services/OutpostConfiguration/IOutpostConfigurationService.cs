using OutPost.Modules.Backoffice.Core.DTO;

namespace OutPost.Modules.Backoffice.Core.Services.OutpostConfiguration;

public interface IOutpostConfigurationService
{
    Task UpdateConfiguration(OutpostConfigurationDto outpostConfigurationDto);
    Task<OutpostConfigurationDto> GetSingle();
}
