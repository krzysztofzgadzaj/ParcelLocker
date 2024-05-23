using Microsoft.AspNetCore.Mvc;

namespace ParcelLocker.Modules.Commission.Api.Controllers;

[ApiController]
[Route(CommissionModule.CommissionModuleUrlPrefix + "/[controller]")]
internal abstract class BaseController : ControllerBase
{
}
