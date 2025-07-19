using team_mapper_api.Endpoints.Tasks;
using team_mapper_shared_utilities.Builders;
using team_mapper_shared_utilities.Stubs;

namespace team_mapper_shared_utilities.SystemUnderTests
{
    public static class GetAllTasksSystemUnderTests
    {
        public static TasksController CreateSystemUndeTest(TasksSubstitute tasksSubstitute)
        {
            tasksSubstitute.TaskService = new TaskServiceBuilder()
                .WithTaskRepository(tasksSubstitute.Repository)
                .Build();

            tasksSubstitute.TaskManager = new TasksManagerBuilder()
                .WithTaskService(tasksSubstitute.TaskService)
                .Build();

            var controller = new TasksController(
                logger: tasksSubstitute.GetAllTasksLogger,
                taskManager: tasksSubstitute.TaskManager);

            return controller;
        }
    }
}
