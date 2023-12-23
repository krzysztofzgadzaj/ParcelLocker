using Microsoft.AspNetCore.Mvc;

namespace ParcelLocker.Modules.Delivery.Api.Controllers;

internal class TestingController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Hello() => Ok("Hello from delivery module");
}
