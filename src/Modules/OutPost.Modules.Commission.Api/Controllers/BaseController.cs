using Microsoft.AspNetCore.Mvc;

namespace OutPost.Modules.Commission.Api.Controllers;

[ApiController]
[Route(CommissionModule.CommissionModuleUrlPrefix + "/[controller]")]
internal abstract class BaseController : ControllerBase
{
}
