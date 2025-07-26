using Microsoft.AspNetCore.Mvc;
using team_mapper_api.Extensions;
using team_mapper_application.Interfaces;

namespace team_mapper_api.Endpoints.Tasks;


public partial class TasksController(ILogger<TasksController> logger, ITaskManager taskManager) : ControllerBase
{
    private ILogger<TasksController> _logger { get; } = logger;
    private ITaskManager _taskManager { get; } = taskManager;

    [HttpGet]
    public async Task<IActionResult> GetAllTasksAsync()
    {
        var correlationId = Request.GetCorrelationId();
        _logger.LogInformation("GetAllTasksAsync Start. CorrelationId {@CorrelationId}", correlationId);

        var results = await _taskManager.GetAllTasksAsync(correlationId);

        _logger.LogInformation("GetAllTasksAsync End. CorrelationId {@CorrelationId}", correlationId);

        return Ok(results);
    }
}
