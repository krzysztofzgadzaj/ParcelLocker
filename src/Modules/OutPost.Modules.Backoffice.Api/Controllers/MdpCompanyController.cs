using Microsoft.AspNetCore.Mvc;
using OutPost.Modules.Backoffice.Core.DTO;
using OutPost.Modules.Backoffice.Core.Services.MdpCompany;

namespace OutPost.Modules.Backoffice.Api.Controllers;

internal class MdpCompanyController : BaseController
{
    private readonly IMdpCompanyService _mdpCompanyService;

    public MdpCompanyController(IMdpCompanyService mdpCompanyService)
    {
        _mdpCompanyService = mdpCompanyService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var mdpCompanies = await _mdpCompanyService.GetMdpCompanies();
        return Ok(mdpCompanies);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(MdpCompanyDto mdpCompanyDto)
    {
        await _mdpCompanyService.CreateMdpCompany(mdpCompanyDto);
        return NoContent();
    }
}
