using Microsoft.AspNetCore.Mvc;
using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.CreateParcelLocker;
using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.CreateShoppingPoint;
using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Queries.GetAvailableMdpsForParcel;
using OutPost.Shared.Infrastructure.Commands;
using OutPost.Shared.Infrastructure.Queries;

namespace OutPost.Modules.Logistics.Api.Controllers;

internal class MediativeDeliveryPointsController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public MediativeDeliveryPointsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    public async Task<IActionResult> GetMediativePoints([FromQuery] GetAvailableMdpsForParcelQuery query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return Ok(result);
    }
    
    [HttpPost("type/parcel-locker")]
    public async Task<IActionResult> CreateParcelLocker([FromBody] CreateParcelLockerCommand command)
    {
        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }
    
    [HttpPost("type/shopping-point")]
    public async Task<IActionResult> CreateShoppingPoint([FromBody] CreateShoppingPointCommand command)
    {
        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }
}
