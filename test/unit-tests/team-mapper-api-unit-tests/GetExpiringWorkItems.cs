﻿using AwesomeAssertions;
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
public class GetExpiringWorkItems
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
    public async Task GivenTasksExists_WhenGetExpiringWorkItemsAsync_ThenShouldReturnTask()
    {
        // Arrange
        var randomTasks = TaskResponseFactory.CreateTasks(5);
        _tasksSubstitute.Repository.GetAllAsync(Arg.Any<Guid>(), Arg.Any<string>()).Returns(randomTasks);

        // Act
        var results = await _systemUnderTest.GetExpiringWorkItemsAsync();

        // Assert
        var controllerResponse = results as ObjectResult;
        var controllerResponseValue = controllerResponse!.Value as List<WorkItem>;
        controllerResponseValue!.Count.Should().Be(randomTasks.Count());
    }

    [Test]
    public async Task GivenNoTasksExists_WhenGetExpiringWorkItemsAsync_ThenShouldReturnEmptyList()
    {
        // Arrange
        _tasksSubstitute.Repository.GetAllAsync(Arg.Any<Guid>(), Arg.Any<string>()).Returns([]);

        // Act
        var results = await _systemUnderTest.GetExpiringWorkItemsAsync();

        // Assert
        var controllerResponse = results as ObjectResult;
        var controllerResponseValue = controllerResponse!.Value as List<WorkItem>;
        controllerResponseValue!.Should().BeNull();
    }

    [Test]
    public void GivenGetAllThrowsException_WhenGetExpiringWorkItemsAsync_ThenShouldReturnInternalServerError()
    {
        // Arrange
        _tasksSubstitute.Repository.GetAllAsync(Arg.Any<Guid>(), Arg.Any<string>()).ThrowsAsync(new Exception("Database error"));

        // Act
        var exception = Assert.ThrowsAsync<Exception>(async () => await _systemUnderTest.GetExpiringWorkItemsAsync());

        // Assert
        exception.Should().NotBeNull();
    }
}
