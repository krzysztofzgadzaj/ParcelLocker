using Microsoft.AspNetCore.Mvc;
using ParcelLocker.Modules.History.Core.DTO;
using ParcelLocker.Modules.History.Core.Services;

namespace ParcelLocker.Modules.History.Api.Controllers;

//TODO: Temporary controller, used to go along with the course. Probably will be replaced with event handler.
internal class HistoryController(IHistoryService historyService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetHistoryLogByIdAsync(int id)
    {
        var history = await historyService.GetLogByIdAsync(id);

        return Ok(history);
    }

    [HttpPost]
    public async Task<IActionResult> CreateHistoryLogAsync(HistoryLogDto historyLogDto)
    {
        await historyService.CrateHistoryLogAsync(historyLogDto);

        return Created();
    }
}
