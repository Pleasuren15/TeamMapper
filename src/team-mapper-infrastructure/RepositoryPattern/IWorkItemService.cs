using team_mapper_domain.Models;

namespace team_mapper_infrastructure.RepositoryPattern;

public interface IWorkItemService
{
    Task<IEnumerable<WorkItem>> GetAllWorkItemsAsync(Guid correlationId);
    Task<Guid> CreateWorkItemAsync(WorkItem workItem, Guid correlationId);
    Task<Guid> UpdateWorkItemAsync(WorkItem workItem, Guid correlationId);
}
