﻿using ParcelLocker.Modules.Backoffice.Core.DTO;
using ParcelLocker.Modules.Backoffice.Core.Mappers;
using ParcelLocker.Modules.Backoffice.Core.Repositories.OutpostConfiguration;

namespace ParcelLocker.Modules.Backoffice.Core.Services.OutpostConfiguration;

public class OutpostConfigurationService : IOutpostConfigurationService
{
    private readonly IOutpostConfigurationRepository _outpostConfigurationRepository;

    public OutpostConfigurationService(IOutpostConfigurationRepository outpostConfigurationRepository)
    {
        _outpostConfigurationRepository = outpostConfigurationRepository;
    }

    public async Task UpdateConfiguration(OutpostConfigurationDto outpostConfigurationDto)
    {
        var outpostConfiguration = await _outpostConfigurationRepository.GetSingle();

        if (outpostConfiguration is null)
        {
            throw new ArgumentException();
        }

        await _outpostConfigurationRepository.UpdateOutpostMarkup(outpostConfigurationDto.Markup);
    }

    public async Task<OutpostConfigurationDto> GetSingle()
    {
        var outpostConfiguration = await _outpostConfigurationRepository.GetSingle();

        if (outpostConfiguration is null)
        {
            throw new ArgumentException();
        }
        
        var outpostConfigurationDto = outpostConfiguration.MapToDto();

        return outpostConfigurationDto;
    }
}
