using AwesomeAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using team_mapper_api.Endpoints.Tasks;
using team_mapper_domain.Models;
using team_mapper_domain.Responses;
using team_mapper_shared_utilities.Substitutes;
using team_mapper_shared_utilities.SystemUnderTests;

namespace team_mapper_api_unit_tests;

[TestFixture]
public class AddWorkItemTests
{
    TasksController _systemUnderTest;
    TasksSubstitute _tasksSubstitute;

    [SetUp]
    public void SetUp()
    {
        _tasksSubstitute = new TasksSubstitute();
        _systemUnderTest = TasksSystemUnderTests.CreateSystemUndeTest(
            tasksSubstitute: _tasksSubstitute);
    }

    [Test]
    public async Task GivenValidWorkItem_WhenCallingCreateWorkItemAsync_ThenShouldReturnSentId()
    {
        // Arrange
        var workItem = new WorkItem();
        _tasksSubstitute.TaskService.CreateWorkItemAsync(Arg.Is(workItem), Arg.Any<Guid>()).Returns(workItem.WorkItemId);

        // Act
        var results = await _systemUnderTest.CreateWorkItemAsync(workItem: workItem);

        // Assert
        var controllerResponse = results as ObjectResult;
        var controllerResponseValue = controllerResponse!.Value as CreateWorkItemResponse;
        controllerResponseValue!.WorkItemId.Should().Be(workItem.WorkItemId);
    }

    [Test]
    public async Task GivenWorkItemAdded_WhenCallingCreateWorkItemAsync_ThenShouldSaveChanges()
    {
        // Arrange
        var workItem = new WorkItem();
        _tasksSubstitute.TaskService.CreateWorkItemAsync(Arg.Is(workItem), Arg.Any<Guid>()).Returns(workItem.WorkItemId);

        // Act
        var results = await _systemUnderTest.CreateWorkItemAsync(workItem: workItem);

        // Assert
        _ = _tasksSubstitute.TaskService.Received(1).CreateWorkItemAsync(Arg.Is(workItem), Arg.Any<Guid>());
    }

    [Test]
    public void GivenErrorThrown_WhenCallingCreateWorkItemAsync_ThenShouldReturnError()
    {
        // Arrange
        const string ExpectedErrorMessage = "Error Was Thrown";
        _tasksSubstitute.TaskService.CreateWorkItemAsync(Arg.Any<WorkItem>(), Arg.Any<Guid>()).Throws(new Exception(ExpectedErrorMessage));

        // Act
        var results = Assert.ThrowsAsync<Exception>(async () => await _systemUnderTest.CreateWorkItemAsync(workItem: new()));

        // Assert
        results.Message.Should().Be(ExpectedErrorMessage);
    }
}
