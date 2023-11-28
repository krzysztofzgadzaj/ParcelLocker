using Microsoft.AspNetCore.Mvc;

namespace ParcelLocker.Modules.History.Api.Controllers;

[Route("history-module")]
internal class HomeController : ControllerBase
{
    public async Task<string> Get() => "From history";
}
