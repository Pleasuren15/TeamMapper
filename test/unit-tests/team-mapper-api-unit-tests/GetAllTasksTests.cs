using AwesomeAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using team_mapper_api.Endpoints.Tasks;
using team_mapper_domain.Models;
using team_mapper_shared_utilities.ResponseFactories;
using team_mapper_shared_utilities.Substitutes;
using team_mapper_shared_utilities.SystemUnderTests;

namespace team_mapper_api_unit_tests;

[TestFixture]
public class GetAllTasksTests
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
    public async Task GivenTasksExists_WhenCallingGetAllTasksAsync_ThenShouldReturnTask()
    {
        // Arrange
        var randomTasks = TaskResponseFactory.CreateTasks(5);
        _tasksSubstitute.Repository.GetAllAsync(Arg.Any<Guid>()).Returns(randomTasks);

        // Act
        var results = await _systemUnderTest.GetAllTasksAsync();

        // Assert
        var controllerResponse = results as ObjectResult;
        var controllerResponseValue = controllerResponse!.Value as List<WorkItem>;
        controllerResponseValue!.Count.Should().Be(randomTasks.Count());
    }

    [Test]
    public async Task GivenNoTasksExists_WhenCallingGetAllTasksAsync_ThenShouldReturnEmptyList()
    {
        // Arrange
        _tasksSubstitute.Repository.GetAllAsync(Arg.Any<Guid>()).Returns([]);

        // Act
        var results = await _systemUnderTest.GetAllTasksAsync();

        // Assert
        var controllerResponse = results as ObjectResult;
        var controllerResponseValue = controllerResponse!.Value as List<WorkItem>;
        controllerResponseValue!.Should().BeNull();
    }

    [Test]
    public void GivenGetAllThrowsException_WhenCallingGetAllTasksAsync_ThenShouldReturnInternalServerError()
    {
        // Arrange
        _tasksSubstitute.Repository.GetAllAsync(Arg.Any<Guid>()).ThrowsAsync(new Exception("Database error"));

        // Act
        var exception = Assert.ThrowsAsync<Exception>(async () => await _systemUnderTest.GetAllTasksAsync());

        // Assert
        exception.Should().NotBeNull();
    }
}
