using team_mapper_domain.Models;
using team_mapper_domain.Responses;

namespace team_mapper_application.Interfaces
{
    public interface ITaskManager
    {
        Task<IEnumerable<WorkItem>> GetAllTasksAsync(Guid correlationId);

        Task<CreateWorkItemResponse> CreateWorkItemAsync(WorkItem workItem, Guid correlationId);
    }
}
