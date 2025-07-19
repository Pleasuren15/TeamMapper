using Microsoft.Extensions.Logging;
using team_mapper_application.Interfaces;
using team_mapper_infrastructure.RepositoryPattern;

namespace team_mapper_application;
public class TaskManager(ITaskService taskService, ILogger<TaskManager> logger) : ITaskManager
{
    private readonly ITaskService _taskService = taskService;
    private readonly ILogger<TaskManager> _logger = logger;

    public async Task<IEnumerable<team_mapper_domain.Models.Task>> GetAllTasksAsync(Guid correlationId)
    {
        try
        {
            _logger.LogInformation("GetAllTasksAsync Start: CorrelationId {@CorrelationId}", correlationId);
            var tasks = await _taskService.GetAllTasksAsync();
            return tasks;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("GetAllTasksAsync Start: CorrelationId {@CorrelationId}", correlationId);
        }
    }
}
