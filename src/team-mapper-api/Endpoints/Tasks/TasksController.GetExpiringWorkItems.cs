using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using team_mapper_api.Extensions;

namespace team_mapper_api.Endpoints.Tasks
{
    public partial class TasksController : ControllerBase
    {
        [HttpGet("/expiringworkitems")]
        public async Task<IActionResult> GetExpiringWorkItemsAsync()
        {
            var correlationId = Request.GetCorrelationId();
            _logger.LogInformation("GetExpiringWorkItemsAsync Start. CorrelationId {@CorrelationId}", correlationId);

            var results = await _taskManager.GetExpiringWorkItemsAsync(correlationId);

            _logger.LogInformation("GetExpiringWorkItemsAsync End. CorrelationId {@CorrelationId}", correlationId);

            return Ok(results);
        }
    }
}
