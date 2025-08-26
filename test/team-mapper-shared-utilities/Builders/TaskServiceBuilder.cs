using Microsoft.Extensions.Logging;
using NSubstitute;
using team_mapper_infrastructure.Interfaces;
using team_mapper_infrastructure.Infrastructure;
using team_mapper_infrastructure.RepositoryPattern;

namespace team_mapper_shared_utilities.Builders;

public class TaskServiceBuilder
{
    private ApplicationDbContext? _dbContext;
    private IPollyPolicyWrapper? _pollyPolicyWrapper;

    public TaskServiceBuilder WithDbContext(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        return this;
    }

    public TaskServiceBuilder WithPollyPolicyWrapper(IPollyPolicyWrapper pollyPolicyWrapper)
    {
        _pollyPolicyWrapper = pollyPolicyWrapper;
        return this;
    }

    public WorkItemService Build()
    {
        return new WorkItemService(
            context: _dbContext ?? Substitute.For<ApplicationDbContext>(),
            pollyPolicyWrapper: _pollyPolicyWrapper ?? Substitute.For<IPollyPolicyWrapper>(),
            logger: Substitute.For<ILogger<WorkItemService>>());
    }
}
