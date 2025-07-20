using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Diagnostics.CodeAnalysis;
using team_mapper_api.Endpoints.Tasks;
using team_mapper_application;
using team_mapper_application.Interfaces;
using team_mapper_infrastructure.RepositoryPattern;

namespace team_mapper_shared_utilities.Stubs
{
    [ExcludeFromCodeCoverage]
    public struct TasksSubstitute()
    {
        public ILogger<TasksController> GetAllTasksLogger = Substitute.For<ILogger<TasksController>>();
        public ITaskManager TaskManager = Substitute.For<ITaskManager>();
        public ITaskService TaskService = Substitute.For<ITaskService>();
        public ILogger<TaskManager> TaskManagerLogger = Substitute.For<ILogger<TaskManager>>();
        public IRepository<team_mapper_domain.Models.Task> Repository = Substitute.For<IRepository<team_mapper_domain.Models.Task>>();
        public ILogger<TaskService> TaskServiceLogger = Substitute.For<ILogger<TaskService>>();
    }
}
