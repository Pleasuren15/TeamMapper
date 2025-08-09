using team_mapper_domain.Models;

namespace team_mapper_application.Interfaces;

public interface ITeamMembersManager
{
    Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync(Guid correlationId);
}
