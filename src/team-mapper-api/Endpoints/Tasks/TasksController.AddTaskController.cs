using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using team_mapper_api.Extensions;
using team_mapper_domain.Models;

namespace team_mapper_api.Endpoints.Tasks;

public partial class TasksController : ControllerBase
{
    [HttpPut("/update")]
    public async Task<IActionResult> UpdateWorkItemAsync(
        [Required][FromBody] WorkItem workItem)
    {
        var correlationId = Request.GetCorrelationId();
        _logger.LogInformation("UpdateWorkItemAsync Start. CorrelationId {@CorrelationId}", correlationId);

        var results = await _taskManager.UpdateWorkItemAsync(
            workItem: workItem,
            correlationId: correlationId);

        _logger.LogInformation("UpdateWorkItemAsync End. CorrelationId {@CorrelationId}", correlationId);

        return Ok(results);
    }
}
