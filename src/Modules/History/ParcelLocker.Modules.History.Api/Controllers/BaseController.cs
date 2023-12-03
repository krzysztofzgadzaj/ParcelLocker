using Microsoft.AspNetCore.Mvc;

namespace ParcelLocker.Modules.History.Api.Controllers;

[ApiController]
[Route(HistoryModuleUrlPrefix + "/[controller]")]
public abstract class BaseController : ControllerBase
{
    private const string HistoryModuleUrlPrefix = "history-module";
}
