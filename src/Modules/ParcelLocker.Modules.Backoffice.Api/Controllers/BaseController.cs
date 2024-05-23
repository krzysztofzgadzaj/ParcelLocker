using Microsoft.AspNetCore.Mvc;

namespace ParcelLocker.Modules.Backoffice.Api.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = BackofficeModule.BackofficeModuleGroupName)]
[Route(BackofficeModule.BackofficeModuleUrlPrefix + "/[controller]")]
internal abstract class BaseController : ControllerBase
{
}
