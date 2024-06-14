using MassTransit;
using Microsoft.AspNetCore.Mvc;
using OutPost.Modules.Commission.Api.Controllers;
using OutPost.Modules.Commission.Application.Events.Internal;

namespace OutPost.Modules.Commission.Api;

internal class DupaController : BaseController
{
    [HttpGet]
    public async Task Siema(IBus bus)
    {
        await bus.Publish(new CommissionCreatedEvent(Guid.NewGuid()));
        Console.WriteLine("hello");
    }
}
