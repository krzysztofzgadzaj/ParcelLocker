using Microsoft.AspNetCore.Mvc;

namespace OutPost.Modules.Payment.Api.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = PaymentModule.PaymentModuleGroupName)]
[Route(PaymentModule.PaymentModuleUrlPrefix + "/[controller]")]
internal abstract class BaseController : ControllerBase
{
}
