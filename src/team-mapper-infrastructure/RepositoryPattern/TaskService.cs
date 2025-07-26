using Microsoft.Extensions.Logging;

namespace team_mapper_infrastructure.RepositoryPattern;

public class TaskService(IRepository<team_mapper_domain.Models.Task> taskRepository, ILogger<TaskService> logger) : ITaskService
{
    private readonly IRepository<team_mapper_domain.Models.Task> _taskRepository = taskRepository;
    private readonly ILogger<TaskService> _logger = logger;

    public async Task<IEnumerable<team_mapper_domain.Models.Task>> GetAllTasksAsync(Guid correlationId)
    {
        _logger.LogInformation("GetAllTasksAsync(TaskService) Start. CorrelationId {@CorrelationId}", correlationId);

        var results = await _taskRepository.GetAllAsync(correlationId);

        _logger.LogInformation("GetAllTasksAsync(TaskService) End. CorrelationId {@CorrelationId} Count {@Count}", correlationId, results.Count());
        return results;
    }
}
