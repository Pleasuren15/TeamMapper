using team_mapper_domain.Models;
using team_mapper_domain.Responses;

namespace team_mapper_application.Interfaces
{
    public interface IWorkItemsManager
    {
        Task<IEnumerable<WorkItem>> GetAllWorkItemsAsync(Guid correlationId);
        Task<IEnumerable<WorkItem>> GetExpiringWorkItemsAsync(Guid correlationId);
        Task<CreateWorkItemResponse> CreateWorkItemAsync(WorkItem workItem, Guid correlationId);
        Task<WorkItem> UpdateWorkItemAsync(WorkItem workItem, Guid correlationId);
    }
}
