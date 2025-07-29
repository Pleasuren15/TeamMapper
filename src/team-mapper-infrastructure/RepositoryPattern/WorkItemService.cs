using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using team_mapper_domain.Models;

namespace team_mapper_infrastructure.RepositoryPattern;

public class WorkItemService(
    IRepository<WorkItem> taskRepository,
    ILogger<WorkItemService> logger) : IWorkItemService
{
    private readonly IRepository<WorkItem> _taskRepository = taskRepository;
    private readonly ILogger<WorkItemService> _logger = logger;

    public async Task<IEnumerable<WorkItem>> GetAllWorkItemsAsync(Guid correlationId)
    {
        _logger.LogInformation("GetAllTasksAsync(TaskService) Start. CorrelationId {@CorrelationId}", correlationId);

        var results = await _taskRepository.GetAllAsync(correlationId: correlationId, relationshipToInclude: nameof(TeamMember));

        _logger.LogInformation("GetAllTasksAsync(TaskService) End. CorrelationId {@CorrelationId} Count {@Count}", correlationId, results.Count());
        return results;
    }

    public async Task<Guid> CreateWorkItemAsync(WorkItem workItem, Guid correlationId)
    {
        _logger.LogInformation("CreateWorkItemAsync Start: WorkItemId {@WorkItemId} CorrelationId {@CorrelationId}", workItem.WorkItemId, correlationId);

        var state = await _taskRepository.AddAsync(entity: workItem, correlationId: correlationId);
        if (state is EntityState.Added)
        {
            await _taskRepository.SaveChangesAsync(correlationId: correlationId);
        }

        _logger.LogInformation("CreateWorkItemAsync End: WorkItemId {@WorkItemId} CorrelationId {@CorrelationId}", workItem.WorkItemId, correlationId);

        return workItem.WorkItemId;
    }

    public async Task<Guid> UpdateWorkItemAsync(WorkItem workItem, Guid correlationId)
    {
        _logger.LogInformation("UpdateWorkItemAsync Start: WorkItemId {@WorkItemId} CorrelationId {@CorrelationId}", workItem.WorkItemId, correlationId);

        var state = await _taskRepository.UpdateAsync(entity: workItem, correlationId: correlationId);
        if (state is EntityState.Added)
        {
            await _taskRepository.SaveChangesAsync(correlationId: correlationId);
        }

        _logger.LogInformation("UpdateWorkItemAsync End: WorkItemId {@WorkItemId} CorrelationId {@CorrelationId}", workItem.WorkItemId, correlationId);

        return workItem.WorkItemId;
    }
}
