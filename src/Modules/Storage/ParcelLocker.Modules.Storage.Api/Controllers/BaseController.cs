using Microsoft.AspNetCore.Mvc;

namespace ParcelLocker.Modules.Storage.Api.Controllers;

[ApiController]
[Route(StorageModule.StorageModuleUrlPrefix + "/[controller]")]
internal abstract class BaseController : ControllerBase
{
}
