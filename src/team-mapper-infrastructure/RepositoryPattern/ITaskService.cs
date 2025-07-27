using team_mapper_domain.Models;

namespace team_mapper_infrastructure.RepositoryPattern;

public interface ITaskService
{
    Task<IEnumerable<WorkItem>> GetAllTasksAsync(Guid correlationId);
    Task<Guid> CreateWorkItemAsync(WorkItem workItem, Guid correlationId);
}
