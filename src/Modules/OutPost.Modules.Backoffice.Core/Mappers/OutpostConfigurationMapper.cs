using OutPost.Modules.Backoffice.Core.DTO;
using OutPost.Modules.Backoffice.Core.Entities;

namespace OutPost.Modules.Backoffice.Core.Mappers;

public static class OutpostConfigurationMapper
{
    public static OutpostConfigurationDto MapToDto(this OutpostConfiguration outpostConfiguration)
        => new()
        {
            Markup = outpostConfiguration.OutpostMarkup
        };
}
