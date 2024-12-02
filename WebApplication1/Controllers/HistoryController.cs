using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HistoryController : ControllerBase
{
    private readonly IHistoryData _historyService;

    public HistoryController(IHistoryData historyService)
    {
        _historyService = historyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _historyService.GetAllAsync();
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] History model)
    {
        var result = await _historyService.AddAsync(model);
        return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] History model)
    {
        var result = await _historyService.UpdateAsync(id, model);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _historyService.DeleteAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}
