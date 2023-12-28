using Microsoft.AspNetCore.Mvc;

namespace ParcelLocker.Modules.Logistics.Api.Controllers;

internal class TestingController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Hello() => Ok("Hello from Logistics module");
}
