using Microsoft.AspNetCore.Mvc;

namespace team_mapper_api.Endpoints.TeamMembers;

[Route("/teammembers")]
[ApiController]
public partial class TeamMembersController(ILogger<TeamMembersController> logger) : ControllerBase
{
    private ILogger<TeamMembersController> _logger { get; } = logger;
}
