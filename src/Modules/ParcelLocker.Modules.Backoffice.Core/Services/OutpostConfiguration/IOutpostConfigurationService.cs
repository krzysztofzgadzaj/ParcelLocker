using ParcelLocker.Modules.Backoffice.Core.DTO;

namespace ParcelLocker.Modules.Backoffice.Core.Services.OutpostConfiguration;

public interface IOutpostConfigurationService
{
    Task UpdateConfiguration(OutpostConfigurationDto outpostConfigurationDto);
    Task<OutpostConfigurationDto> GetSingle();
}
