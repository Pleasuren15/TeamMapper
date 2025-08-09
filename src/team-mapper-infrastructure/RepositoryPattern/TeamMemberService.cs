using Microsoft.Extensions.Logging;
using team_mapper_domain.Models;

namespace team_mapper_infrastructure.RepositoryPattern;

public class TeamMemberService(
    IRepository<TeamMember> taskRepository,
    ILogger<TeamMemberService> logger) : ITeamMemberService
{
    private readonly IRepository<TeamMember> _taskRepository = taskRepository;
    private readonly ILogger<TeamMemberService> _logger = logger;

    public async Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync(Guid correlationId)
    {
        _logger.LogInformation("GetAllTeamMembersAsync(TaskService) Start. CorrelationId {@CorrelationId}", correlationId);

        var results = await _taskRepository.GetAllAsync(correlationId: correlationId, relationshipToInclude: null!);

        _logger.LogInformation("GetAllTeamMembersAsync(TaskService) End. CorrelationId {@CorrelationId} Count {@Count}", correlationId, results.Count());
        return results;
    }
}
