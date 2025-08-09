using Microsoft.Extensions.Logging;
using team_mapper_application.Interfaces;
using team_mapper_domain.Models;

namespace team_mapper_application;

public class TeamMembersManager(ILogger<WorkItemsManager> logger) : ITeamMembersManager
{
    private readonly ILogger<WorkItemsManager> _logger = logger;

    public async Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync(Guid correlationId)
    {
        try
        {
            _logger.LogInformation("GetAllTeamMembersAsync Start: CorrelationId {@CorrelationId}", correlationId);

            return default!;
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
