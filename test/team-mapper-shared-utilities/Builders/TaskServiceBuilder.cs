using team_mapper_infrastructure.RepositoryPattern;

namespace team_mapper_shared_utilities.Builders;

public class TaskServiceBuilder
{
    private IRepository<team_mapper_domain.Models.Task> _taskRepository;

    public TaskServiceBuilder WithTaskRepository(IRepository<team_mapper_domain.Models.Task> taskRepository)
    {
        _taskRepository = taskRepository;
        return this;
    }
    public TaskService Build()
    {
        return new TaskService(
            taskRepository: _taskRepository);
    }
}
