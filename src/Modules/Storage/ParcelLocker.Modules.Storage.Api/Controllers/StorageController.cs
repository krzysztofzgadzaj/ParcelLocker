using Microsoft.AspNetCore.Mvc;
using ParcelLocker.Modules.Storage.Core.Services;

namespace ParcelLocker.Modules.Storage.Api.Controllers;

internal class StorageController : BaseController
{
    private readonly IStorageService _storageService;

    public StorageController(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetStorageByIdAsync([FromRoute] Guid id)
    {
        var storage = await _storageService.GetByIdAsync(id);

        return Ok(storage);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateStorageAsync([FromBody] Core.Entities.Storage storage)
    {
        await _storageService.CreateAsync(storage);

        return Created();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpateStorageAsync([FromRoute] Guid id)
    {
        await _storageService.UpdateAsync(id);

        return NoContent();
    }
}
