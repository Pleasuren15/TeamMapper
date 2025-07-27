using Microsoft.AspNetCore.Mvc;
using team_mapper_application.Interfaces;

namespace team_mapper_api.Endpoints.Tasks;

[Route("tasks")]
[ApiController]
public partial class TasksController(ILogger<TasksController> logger, ITaskManager taskManager) : ControllerBase
{
    private ILogger<TasksController> _logger { get; } = logger;
    private ITaskManager _taskManager { get; } = taskManager;
}
