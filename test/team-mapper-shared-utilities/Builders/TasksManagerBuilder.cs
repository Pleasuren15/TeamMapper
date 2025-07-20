using Microsoft.Extensions.Logging;
using NSubstitute;
using team_mapper_application;
using team_mapper_infrastructure.RepositoryPattern;

namespace team_mapper_shared_utilities.Builders;

public class TasksManagerBuilder
{
    private ITaskService? _taskService { get; set; }
    private readonly ILogger<TaskManager> TaskManagerlogger = Substitute.For<ILogger<TaskManager>>();

    public TasksManagerBuilder WithTaskService(ITaskService taskService)
    {
        this._taskService = taskService;
        return this;
    }

    public TaskManager Build()
    {
        return new TaskManager(
            taskService: _taskService!,
            logger: TaskManagerlogger);
    }
}
