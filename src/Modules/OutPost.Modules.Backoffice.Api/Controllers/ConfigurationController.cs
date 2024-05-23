using Microsoft.AspNetCore.Mvc;
using OutPost.Modules.Backoffice.Core.DTO;
using OutPost.Modules.Backoffice.Core.Services.OutpostConfiguration;

namespace OutPost.Modules.Backoffice.Api.Controllers;

internal class ConfigurationController : BaseController
{
    private readonly IOutpostConfigurationService _configurationService;

    public ConfigurationController(IOutpostConfigurationService configurationService)
    {
        _configurationService = configurationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetConfiguration()
    {
        var configuration = await _configurationService.GetSingle();
        return Ok(configuration);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateConfiguration(OutpostConfigurationDto outpostConfigurationDto)
    {
        await _configurationService.UpdateConfiguration(outpostConfigurationDto);
        return NoContent();
    }
}
