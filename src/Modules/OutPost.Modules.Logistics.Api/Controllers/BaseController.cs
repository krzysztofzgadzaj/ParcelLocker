using Microsoft.AspNetCore.Mvc;

namespace OutPost.Modules.Logistics.Api.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = LogisticsModule.LogisticsModuleGroupName)]
[Route(LogisticsModule.LogisticsModuleUrlPrefix + "/[controller]")]
internal abstract class BaseController : ControllerBase
{
}
