using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using team_mapper_domain.Models;
using team_mapper_infrastructure.Infrastructure;
using team_mapper_infrastructure.Interfaces;

namespace team_mapper_infrastructure.RepositoryPattern;

public class TeamMemberService(
    ApplicationDbContext context,
    IPollyPolicyWrapper pollyPolicyWrapper,
    ILogger<TeamMemberService> logger) : ITeamMemberService
{
    private readonly ApplicationDbContext _context = context;
    private readonly IPollyPolicyWrapper _pollyPolicyWrapper = pollyPolicyWrapper;
    private readonly ILogger<TeamMemberService> _logger = logger;

    public async Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync(Guid correlationId)
    {
        _logger.LogInformation("GetAllTeamMembersAsync(TaskService) Start. CorrelationId {@CorrelationId}", correlationId);

        var results = await _pollyPolicyWrapper.ExecuteWithPollyRetryPolicyAsync<Exception, IEnumerable<TeamMember>>(
            async () => await _context.TeamMembers.AsNoTracking().ToListAsync());

        _logger.LogInformation("GetAllTeamMembersAsync(TaskService) End. CorrelationId {@CorrelationId} Count {@Count}", correlationId, results.Count());
        return results;
    }
}
