using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using team_mapper_api.Extensions;
using team_mapper_domain.Models;

namespace team_mapper_api.Endpoints.Tasks;

public partial class TasksController : ControllerBase
{
    [HttpPost("/workitems")]
    public async Task<IActionResult> CreateWorkItemAsync(
    [Required][FromBody] WorkItem workItem)
    {
        var correlationId = Request.GetCorrelationId();
        _logger.LogInformation("AddTaskAsync Start. CorrelationId {@CorrelationId}", correlationId);

        var results = await _taskManager.CreateWorkItemAsync(
            workItem: workItem,
            correlationId: correlationId);

        _logger.LogInformation("AddTaskAsync End. CorrelationId {@CorrelationId}", correlationId);

        return Ok(results);
    }
}
