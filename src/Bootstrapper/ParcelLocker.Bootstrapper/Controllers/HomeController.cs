using Microsoft.AspNetCore.Mvc;

namespace Bootstrapper.Controllers;

[Route("")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public async Task<string> Get() => "From bootsrapper";
}
