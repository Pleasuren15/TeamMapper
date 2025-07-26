using Microsoft.Extensions.Logging;
using NSubstitute;
using team_mapper_infrastructure.Interfaces;
using team_mapper_infrastructure.RepositoryPattern;

namespace team_mapper_shared_utilities.Builders;

public class TaskServiceBuilder
{
    private IRepository<team_mapper_domain.Models.Task>? _taskRepository;
    IPollyPolicyWrapper? pollyPolicyWrapper;

    public TaskServiceBuilder WithTaskRepository(IRepository<team_mapper_domain.Models.Task> taskRepository)
    {
        _taskRepository = taskRepository;
        return this;
    }
    public TaskServiceBuilder WithPollyPolicyWrapper(IPollyPolicyWrapper policyWrapper)
    {
        pollyPolicyWrapper = policyWrapper;
        return this;
    }

    public TaskService Build()
    {
        return new TaskService(
            taskRepository: _taskRepository ?? Substitute.For<IRepository<team_mapper_domain.Models.Task>>(),
            pollyPolicyWrapper: pollyPolicyWrapper ?? Substitute.For<IPollyPolicyWrapper>(),
            logger: Substitute.For<ILogger<TaskService>>());
    }
}
