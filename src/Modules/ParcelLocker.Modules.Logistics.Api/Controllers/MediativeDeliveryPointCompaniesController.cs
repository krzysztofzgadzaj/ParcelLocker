using Microsoft.AspNetCore.Mvc;
using ParcelLocker.Modules.Logistics.Application.MediativeDeliveryPoints.Queries.GetMdpCompanies;
using ParcelLocker.Shared.Infrastructure.Queries;

namespace ParcelLocker.Modules.Logistics.Api.Controllers;

internal class MediativeDeliveryPointCompaniesController : BaseController
{
    private readonly IQueryDispatcher _queryDispatcher;

    public MediativeDeliveryPointCompaniesController(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateParcelLocker()
    {
        var mdpCompanies = await _queryDispatcher.QueryAsync(new GetMdpCompaniesQuery());
        return Ok(mdpCompanies);
    }
}
