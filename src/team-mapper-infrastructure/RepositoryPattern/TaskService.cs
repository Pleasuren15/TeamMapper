using Microsoft.Extensions.Logging;
using team_mapper_infrastructure.Interfaces;

namespace team_mapper_infrastructure.RepositoryPattern;

public class TaskService(
    IRepository<team_mapper_domain.Models.Task> taskRepository,
    IPollyPolicyWrapper pollyPolicyWrapper,
    ILogger<TaskService> logger) : ITaskService
{
    private readonly IRepository<team_mapper_domain.Models.Task> _taskRepository = taskRepository;
    private readonly IPollyPolicyWrapper _pollyPolicyWrapper = pollyPolicyWrapper;
    private readonly ILogger<TaskService> _logger = logger;

    public async Task<IEnumerable<team_mapper_domain.Models.Task>> GetAllTasksAsync(Guid correlationId)
    {
        _logger.LogInformation("GetAllTasksAsync(TaskService) Start. CorrelationId {@CorrelationId}", correlationId);

        var results = await _pollyPolicyWrapper.Policy
            .Execute(() => _taskRepository.GetAllAsync(correlationId: correlationId));

        _logger.LogInformation("GetAllTasksAsync(TaskService) End. CorrelationId {@CorrelationId} Count {@Count}", correlationId, results.Count());
        return results;
    }
}
