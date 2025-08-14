using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using team_mapper_api.Endpoints.Tasks;
using team_mapper_shared_utilities.Builders;
using team_mapper_shared_utilities.Substitutes;

namespace team_mapper_shared_utilities.SystemUnderTests;

public static class TasksSystemUnderTests
{
    public static TasksController CreateSystemUndeTest(TasksSubstitute tasksSubstitute)
    {
        tasksSubstitute.TaskService = new TaskServiceBuilder()
            .WithDbContext(tasksSubstitute.DbContext)
            .WithPollyPolicyWrapper(tasksSubstitute.PollyPolicyWrapper)
            .Build();

        tasksSubstitute.TaskManager = new TasksManagerBuilder()
            .WithTaskService(tasksSubstitute.TaskService)
            .Build();

        var controller = new TasksController(
            logger: tasksSubstitute.GetAllTasksLogger,
            taskManager: tasksSubstitute.TaskManager)
        {
            ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext(),
            }
        };
        controller.HttpContext.Request.Headers["X-Correlation-ID"] = $"{Guid.NewGuid()}";

        return controller;
    }
}
