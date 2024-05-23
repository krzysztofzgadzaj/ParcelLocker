using Microsoft.AspNetCore.Mvc;
using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.CreateParcelLocker;
using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.CreateShoppingPoint;
using OutPost.Shared.Infrastructure.Commands;

namespace OutPost.Modules.Logistics.Api.Controllers;

internal class MediativeDeliveryPointsController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;

    public MediativeDeliveryPointsController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
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
