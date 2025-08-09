using team_mapper_domain.Models;

namespace team_mapper_infrastructure.RepositoryPattern;

public interface ITeamMemberService
{
    Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync(Guid correlationId);
}
