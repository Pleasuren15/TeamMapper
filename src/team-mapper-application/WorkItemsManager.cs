﻿using Microsoft.Extensions.Logging;
using team_mapper_application.Interfaces;
using team_mapper_domain.Models;
using team_mapper_domain.Responses;
using team_mapper_infrastructure.RepositoryPattern;

namespace team_mapper_application;
public class WorkItemsManager(IWorkItemService taskService, ILogger<WorkItemsManager> logger) : IWorkItemsManager
{
    private readonly IWorkItemService _taskService = taskService;
    private readonly ILogger<WorkItemsManager> _logger = logger;

    public async Task<IEnumerable<WorkItem>> GetAllWorkItemsAsync(Guid correlationId)
    {
        try
        {
            _logger.LogInformation("GetAllTasksAsync Start: CorrelationId {@CorrelationId}", correlationId);

            var tasks = await _taskService.GetAllWorkItemsAsync(correlationId: correlationId);
            return tasks;
        }
        catch (Exception exception)
        {
            _logger.LogError("GetAllTasksAsync Error: Message {@Message}", exception.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("GetAllTasksAsync Start: CorrelationId {@CorrelationId}", correlationId);
        }
    }

    public async Task<IEnumerable<WorkItem>> GetExpiringWorkItemsAsync(Guid correlationId)
    {
        try
        {
            _logger.LogInformation("GetExpiringWorkItemsAsync Start: CorrelationId {@CorrelationId}", correlationId);

            var allWorkItems = await _taskService.GetAllWorkItemsAsync(correlationId: correlationId);
            var expiringTasks = allWorkItems.Where(task => task.EndDate > DateTime.Now && task.EndDate < DateTime.UtcNow.AddDays(7));

            return allWorkItems;
        }
        catch (Exception exception)
        {
            _logger.LogError("GetExpiringWorkItemsAsync Error: Message {@Message}", exception.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("GetExpiringWorkItemsAsync Start: CorrelationId {@CorrelationId}", correlationId);
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
            _logger.LogError("CreateWorkItemAsync Error: WorkItemId {@WorkItemId} Message {@Message}", workItem.WorkItemId, exception.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("CreateWorkItemAsync End: WorkItemId {@WorkItemId} CorrelationId {@CorrelationId}", workItem.WorkItemId, correlationId);
        }
    }

    public async Task<WorkItem> UpdateWorkItemAsync(WorkItem workItem, Guid correlationId)
    {
        try
        {
            _logger.LogInformation("UpdateWorkItemAsync Start: WorkItemId {@WorkItemId} CorrelationId {@CorrelationId}", workItem.WorkItemId, correlationId);

            var tasks = await _taskService.UpdateWorkItemAsync(
                workItem: workItem,
                correlationId: correlationId);

            return workItem;
        }
        catch (Exception exception)
        {
            _logger.LogError("UpdateWorkItemAsync Error: WorkItemId {@WorkItemId} Message {@Message}", workItem.WorkItemId, exception.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("UpdateWorkItemAsync End: WorkItemId {@WorkItemId} CorrelationId {@CorrelationId}", workItem.WorkItemId, correlationId);
        }
    }
}
