using Microsoft.Extensions.Logging;
using team_mapper_application.Interfaces;
using team_mapper_domain.Models;
using team_mapper_domain.Responses;
using team_mapper_infrastructure.RepositoryPattern;

namespace team_mapper_application;
public class TaskManager(ITaskService taskService, ILogger<TaskManager> logger) : ITaskManager
{
    private readonly ITaskService _taskService = taskService;
    private readonly ILogger<TaskManager> _logger = logger;

    public async Task<IEnumerable<WorkItem>> GetAllTasksAsync(Guid correlationId)
    {
        try
        {
            _logger.LogInformation("GetAllTasksAsync Start: CorrelationId {@CorrelationId}", correlationId);

            var tasks = await _taskService.GetAllTasksAsync(correlationId: correlationId);
            return tasks;
        }
        catch (Exception exception)
        {
            _logger.LogError("Error Message {@Message}", exception.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("GetAllTasksAsync Start: CorrelationId {@CorrelationId}", correlationId);
        }
    }

    public async Task<CreateWorkItemResponse> CreateWorkItemAsync(WorkItem workItem, Guid correlationId)
    {
        try
        {
            _logger.LogInformation("CreateWorkItemAsync Start: WorkItemId {@WorkItemId} CorrelationId {@CorrelationId}", workItem.WorkItemId, correlationId);

            var tasks = await _taskService.CreateWorkItemAsync(
                workItem: workItem,
                correlationId: correlationId);

            return new(workItemId: workItem.WorkItemId);
        }
        catch (Exception exception)
        {
            _logger.LogError("CreateWorkItemAsync:  Error WorkItemId {@WorkItemId} Message {@Message}", workItem.WorkItemId, exception.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("CreateWorkItemAsync End: WorkItemId {@WorkItemId} CorrelationId {@CorrelationId}", workItem.WorkItemId, correlationId);
        }
    }
}
