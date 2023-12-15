using Microsoft.AspNetCore.Mvc;

namespace ParcelLocker.Modules.History.Api.Controllers;

[ApiController]
[Route(HistoryModule.HistoryModuleUrlPrefix + "/[controller]")]
internal abstract class BaseController : ControllerBase
{
}
