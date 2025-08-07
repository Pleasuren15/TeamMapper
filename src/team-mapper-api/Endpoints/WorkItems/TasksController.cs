using Microsoft.AspNetCore.Mvc;
using team_mapper_application.Interfaces;

namespace team_mapper_api.Endpoints.Tasks;

[Route("/workitems")]
[ApiController]
public partial class TasksController(ILogger<TasksController> logger, IWorkItemsManager taskManager) : ControllerBase
{
    private ILogger<TasksController> _logger { get; } = logger;
    private IWorkItemsManager _taskManager { get; } = taskManager;
}
