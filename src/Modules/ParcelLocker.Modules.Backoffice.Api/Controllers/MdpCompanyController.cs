using Microsoft.AspNetCore.Mvc;
using ParcelLocker.Modules.Backoffice.Core.DTO;
using ParcelLocker.Modules.Backoffice.Core.Services.MdpCompany;

namespace ParcelLocker.Modules.Backoffice.Api.Controllers;

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
