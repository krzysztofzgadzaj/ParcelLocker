using ParcelLocker.Modules.Backoffice.Core.DTO;
using ParcelLocker.Modules.Backoffice.Core.Entities;

namespace ParcelLocker.Modules.Backoffice.Core.Mappers;

public static class OutpostConfigurationMapper
{
    public static OutpostConfigurationDto MapToDto(this OutpostConfiguration outpostConfiguration)
        => new()
        {
            Markup = outpostConfiguration.OutpostMarkup
        };
}
