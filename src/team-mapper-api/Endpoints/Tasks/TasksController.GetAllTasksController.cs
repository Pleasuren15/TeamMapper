using Microsoft.AspNetCore.Mvc;
using team_mapper_api.Extensions;

namespace team_mapper_api.Endpoints.Tasks;

public partial class TasksController : ControllerBase
{
    [HttpGet("/tasks")]
    public async Task<IActionResult> GetAllTasksAsync()
    {
        var correlationId = Request.GetCorrelationId();
        _logger.LogInformation("GetAllTasksAsync Start. CorrelationId {@CorrelationId}", correlationId);

        var results = await _taskManager.GetAllTasksAsync(correlationId);

        _logger.LogInformation("GetAllTasksAsync End. CorrelationId {@CorrelationId}", correlationId);

        return Ok(results);
    }
}
