using Microsoft.Extensions.Logging;
using team_mapper_application.Interfaces;
using team_mapper_domain.Models;
using team_mapper_infrastructure.RepositoryPattern;

namespace team_mapper_application;

public class TeamMembersManager(ILogger<WorkItemsManager> logger, ITeamMemberService teamMemberService) : ITeamMembersManager
{
    private readonly ILogger<WorkItemsManager> _logger = logger;
    private readonly ITeamMemberService _teamMemberService = teamMemberService;

    public async Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync(Guid correlationId)
    {
        try
        {
            _logger.LogInformation("GetAllTeamMembersAsync Start: CorrelationId {@CorrelationId}", correlationId);
            var results = await _teamMemberService.GetAllTeamMembersAsync(correlationId);

            return results;
        }
        catch (Exception exception)
        {
            _logger.LogError("GetAllTeamMembersAsync Error: Message {@Message}", exception.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("GetAllTeamMembersAsync Start: CorrelationId {@CorrelationId}", correlationId);
        }
    }
}
