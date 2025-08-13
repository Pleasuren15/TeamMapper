using Microsoft.AspNetCore.Mvc;
using team_mapper_api.Extensions;

namespace team_mapper_api.Endpoints.TeamMembers
{
    public partial class TeamMembersController
    {
        [HttpGet("/teammembers")]
        public async Task<IActionResult> GetAllTeamMembersAsync()
        {
            var correlationId = Request.GetCorrelationId();
            _logger.LogInformation("GetAllTeamMembersAsync Start. CorrelationId {@CorrelationId}", correlationId);

            var results = await _teamMembersManager.GetAllTeamMembersAsync(correlationId);

            _logger.LogInformation("GetAllTeamMembersAsync End. CorrelationId {@CorrelationId}", correlationId);

            return Ok(results);
        }
    }
}
