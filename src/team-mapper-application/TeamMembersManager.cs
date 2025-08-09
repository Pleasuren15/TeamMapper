using team_mapper_application.Interfaces;
using team_mapper_domain.Models;

namespace team_mapper_application;

public class TeamMembersManager : ITeamMembersManager
{
    public async Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync(Guid correlationId)
    {
        throw new NotImplementedException();
    }
}
