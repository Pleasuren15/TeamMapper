using Microsoft.Extensions.Logging;
using NSubstitute;
using team_mapper_application;
using team_mapper_infrastructure.RepositoryPattern;

namespace team_mapper_shared_utilities.Builders;

public class TasksManagerBuilder
{
    private IWorkItemService? _taskService { get; set; }
    private readonly ILogger<WorkItemsManager> TaskManagerlogger = Substitute.For<ILogger<WorkItemsManager>>();

    public TasksManagerBuilder WithTaskService(IWorkItemService taskService)
    {
        this._taskService = taskService;
        return this;
    }

    public WorkItemsManager Build()
    {
        return new WorkItemsManager(
            taskService: _taskService!,
            logger: TaskManagerlogger);
    }
}
