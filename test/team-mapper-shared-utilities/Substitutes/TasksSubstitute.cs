﻿using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Diagnostics.CodeAnalysis;
using team_mapper_api.Endpoints.Tasks;
using team_mapper_application;
using team_mapper_application.Interfaces;
using team_mapper_infrastructure.Interfaces;
using team_mapper_infrastructure.RepositoryPattern;

namespace team_mapper_shared_utilities.Substitutes;

[ExcludeFromCodeCoverage]
public struct TasksSubstitute()
{
    public ILogger<TasksController> GetAllTasksLogger = Substitute.For<ILogger<TasksController>>();
    public ILogger<WorkItemsManager> TaskManagerLogger = Substitute.For<ILogger<WorkItemsManager>>();
    public ILogger<WorkItemService> TaskServiceLogger = Substitute.For<ILogger<WorkItemService>>();

    public IWorkItemsManager TaskManager = Substitute.For<IWorkItemsManager>();
    public IWorkItemService TaskService = Substitute.For<IWorkItemService>();
    public IRepository<team_mapper_domain.Models.WorkItem> Repository = Substitute.For<IRepository<team_mapper_domain.Models.WorkItem>>();
    public IPollyPolicyWrapper PollyPolicyWrapper = Substitute.For<IPollyPolicyWrapper>();
}
