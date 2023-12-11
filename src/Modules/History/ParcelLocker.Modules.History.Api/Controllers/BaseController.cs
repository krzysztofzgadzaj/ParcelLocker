using Microsoft.AspNetCore.Mvc;

namespace ParcelLocker.Modules.History.Api.Controllers;

[ApiController]
[Route(HistoryModule.HistoryModuleUrlPrefix + "/[controller]")]
public abstract class BaseController : ControllerBase
{
}
