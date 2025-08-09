using Microsoft.AspNetCore.Mvc;
using team_mapper_application.Interfaces;

namespace team_mapper_api.Endpoints.TeamMembers;

[Route("/teammembers")]
[ApiController]
public partial class TeamMembersController(ILogger<TeamMembersController> logger, ITeamMembersManager teamMembersManager) : ControllerBase
{
    private ILogger<TeamMembersController> _logger { get; } = logger;
    private ITeamMembersManager _teamMembersManager { get; } = teamMembersManager;
}
