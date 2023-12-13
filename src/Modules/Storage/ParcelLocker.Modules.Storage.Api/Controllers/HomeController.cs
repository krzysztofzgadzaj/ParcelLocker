using Microsoft.AspNetCore.Mvc;

namespace ParcelLocker.Modules.Storage.Api.Controllers;

internal class HomeController : BaseController
{
    [HttpGet]
    public async Task<string> Get() => "From storage";
}
