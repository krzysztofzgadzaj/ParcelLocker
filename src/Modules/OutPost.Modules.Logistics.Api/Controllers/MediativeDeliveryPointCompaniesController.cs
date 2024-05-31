using Microsoft.AspNetCore.Mvc;
using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Queries.GetMdpCompanies;
using OutPost.Shared.Infrastructure.Queries;

namespace OutPost.Modules.Logistics.Api.Controllers;

internal class MediativeDeliveryPointCompaniesController : BaseController
{
    private readonly IQueryDispatcher _queryDispatcher;

    public MediativeDeliveryPointCompaniesController(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMdpCompanies()
    {
        var mdpCompanies = await _queryDispatcher.QueryAsync(new GetMdpCompaniesQuery());
        return Ok(mdpCompanies);
    }
}
