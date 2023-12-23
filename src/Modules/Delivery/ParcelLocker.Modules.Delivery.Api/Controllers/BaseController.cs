using Microsoft.AspNetCore.Mvc;

namespace ParcelLocker.Modules.Delivery.Api.Controllers;

[ApiController]
[Route(DeliveryModule.DeliveryModuleUrlPrefix + "/[controller]")]
internal abstract class BaseController : ControllerBase
{
}
