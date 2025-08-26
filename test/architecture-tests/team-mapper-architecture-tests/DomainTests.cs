using AwesomeAssertions;
using NetArchTest.Rules;
using team_mapper_domain.Models;

namespace team_mapper_architecture_tests;

public class Tests
{
    [TestCase(nameof(team_mapper_application))]
    [TestCase(nameof(team_mapper_api))]
    [TestCase(nameof(team_mapper_infrastructure))]
    public void GivenDomainAssembly_ThenShouldNotDependOnAnyAssemblies(string _namespace)
    {
        // Arrange
        var domainAssembly = typeof(WorkItem).Assembly;

        // Act
        var result = Types.InAssembly(domainAssembly)
            .Should()
            .NotHaveDependencyOn(_namespace)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Test]
    public void GivenDomainAssembly_WhenNamingClasses_ThenShouldFollowPascalCase()
    {
        // Arrange
        var domainAssembly = typeof(WorkItem).Assembly;

        // Act
        var result = Types.InAssembly(domainAssembly)
            .Should()
            .HaveNameMatching("^(?:[A-Z][a-z0-9]+)+$")
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
}
