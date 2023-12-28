using Microsoft.AspNetCore.Mvc;

namespace ParcelLocker.Modules.Logistics.Api.Controllers;

[ApiController]
[Route(LogisticsModule.LogisticsModuleUrlPrefix + "/[controller]")]
internal abstract class BaseController : ControllerBase
{
}
