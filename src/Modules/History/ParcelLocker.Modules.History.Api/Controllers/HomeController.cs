using Microsoft.AspNetCore.Mvc;

namespace ParcelLocker.Modules.History.Api.Controllers;

internal class HomeController : BaseController
{
    [HttpGet]
    public async Task<string> Get() => "From history";
}
