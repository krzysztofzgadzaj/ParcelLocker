using Microsoft.AspNetCore.Mvc;

namespace ParcelLocker.Modules.Logistics.Api.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = LogisticsModule.LogisticsModuleGroupName)]
[Route(LogisticsModule.LogisticsModuleUrlPrefix + "/[controller]")]
internal abstract class BaseController : ControllerBase
{
}
