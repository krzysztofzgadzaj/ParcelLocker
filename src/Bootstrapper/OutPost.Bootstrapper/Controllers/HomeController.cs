using Microsoft.AspNetCore.Mvc;

namespace OutPost.Bootstrapper.Controllers;

[Route("")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public async Task<string> Get() => "From bootsrapper";
}
