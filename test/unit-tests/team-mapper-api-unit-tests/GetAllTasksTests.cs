using AwesomeAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using team_mapper_api.Endpoints.Tasks;
using team_mapper_shared_utilities.ResponseFactories;
using team_mapper_shared_utilities.Stubs;
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
        _systemUnderTest = GetAllTasksSystemUnderTests.CreateSystemUndeTest(
            tasksSubstitute: _tasksSubstitute);
    }

    [Test]
    public async Task GivenTasksExists_WhenCallingGetAllTasksAsync_ThenShouldReturnTask()
    {
        // Arrange
        var randomTasks = TaskResponseFactory.CreateTasks(5);
        _tasksSubstitute.Repository.GetAllAsync().Returns(randomTasks);

        // Act
        var results = await _systemUnderTest.GetAllTasksAsync();

        // Assert
        var controllerResponse = results as ObjectResult;
        var controllerResponseValue = controllerResponse!.Value as List<team_mapper_domain.Models.Task>;
        controllerResponseValue!.Count.Should().Be(randomTasks.Count());
    }

    [TearDown]
    public void TearDown()
    {
        _systemUnderTest.Dispose();
    }
}
