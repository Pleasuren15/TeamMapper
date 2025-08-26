using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using team_mapper_domain.Models;
using team_mapper_infrastructure.Infrastructure;
using team_mapper_infrastructure.Interfaces;

namespace team_mapper_infrastructure.RepositoryPattern;

public class WorkItemService(
    ApplicationDbContext context,
    IPollyPolicyWrapper pollyPolicyWrapper,
    ILogger<WorkItemService> logger) : IWorkItemService
{
    private readonly ApplicationDbContext _context = context;
    private readonly IPollyPolicyWrapper _pollyPolicyWrapper = pollyPolicyWrapper;
    private readonly ILogger<WorkItemService> _logger = logger;

    public async Task<IEnumerable<WorkItem>> GetAllWorkItemsAsync(Guid correlationId)
    {
        _logger.LogInformation("GetAllTasksAsync(TaskService) Start. CorrelationId {@CorrelationId}", correlationId);

        var results = await _pollyPolicyWrapper.ExecuteWithPollyRetryPolicyAsync<Exception, IEnumerable<WorkItem>>(
            async () => await _context.WorkItems.AsNoTracking().Include(w => w.TeamMember).ToListAsync());

        _logger.LogInformation("GetAllTasksAsync(TaskService) End. CorrelationId {@CorrelationId} Count {@Count}", correlationId, results.Count());
        return results;
    }

    public async Task<Guid> CreateWorkItemAsync(WorkItem workItem, Guid correlationId)
    {
        _logger.LogInformation("CreateWorkItemAsync Start: WorkItemId {@WorkItemId} CorrelationId {@CorrelationId}", workItem.WorkItemId, correlationId);

        var entity = await _pollyPolicyWrapper.ExecuteWithPollyRetryPolicyAsync<Exception, Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<WorkItem>>(
            async () => await _context.WorkItems.AddAsync(workItem));
        
        if (entity.State is EntityState.Added)
        {
            await _context.SaveChangesAsync();
        }

        _logger.LogInformation("CreateWorkItemAsync End: WorkItemId {@WorkItemId} CorrelationId {@CorrelationId}", workItem.WorkItemId, correlationId);

        return workItem.WorkItemId;
    }

    public async Task<Guid> UpdateWorkItemAsync(WorkItem workItem, Guid correlationId)
    {
        _logger.LogInformation("UpdateWorkItemAsync Start: WorkItemId {@WorkItemId} CorrelationId {@CorrelationId}", workItem.WorkItemId, correlationId);

        _context.WorkItems.Update(workItem);
        await _context.SaveChangesAsync();

        _logger.LogInformation("UpdateWorkItemAsync End: WorkItemId {@WorkItemId} CorrelationId {@CorrelationId}", workItem.WorkItemId, correlationId);

        return workItem.WorkItemId;
    }
}
