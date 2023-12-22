using Microsoft.AspNetCore.Mvc;
using ParcelLocker.Modules.History.Core.Commands;
using ParcelLocker.Modules.History.Core.DTO;
using ParcelLocker.Modules.History.Core.Queries;
using ParcelLocker.Modules.History.Core.Services;
using ParcelLocker.Shared.Infrastructure.Commands;
using ParcelLocker.Shared.Infrastructure.Queries;

namespace ParcelLocker.Modules.History.Api.Controllers;

//TODO: Temporary controller, used to go along with the course. Probably will be replaced with event handler.
internal class HistoryController : BaseController
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IHistoryService _historyService;

    public HistoryController(IHistoryService historyService, IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
    {
        _historyService = historyService;
        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }

    [HttpGet]
    public async Task<IActionResult> GetHistoryLogByIdAsync(int id)
    {
        var query = new TempQuery();
        await _queryDispatcher.QueryAsync(query);
        
        var history = await _historyService.GetLogByIdAsync(id);

        return Ok(history);
    }

    [HttpPost]
    public async Task<IActionResult> CreateHistoryLogAsync(HistoryLogDto historyLogDto)
    {
        var command = new TempCommand();
        await _commandDispatcher.SendAsync(command);
        
        await _historyService.CrateHistoryLogAsync(historyLogDto);

        return Created();
    }
}
