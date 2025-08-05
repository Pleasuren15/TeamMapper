using Microsoft.Extensions.Logging;
using team_mapper_application.Interfaces;

namespace team_mapper_application.Services;

public class ExpiringWorkItemsService(ILogger<ExpiringWorkItemsCronService> logger, IWorkItemsManager workItemsManager) : IExpiringWorkItemsService
{
    private readonly ILogger<ExpiringWorkItemsCronService> _logger = logger;
    private readonly IWorkItemsManager _workItemsManager = workItemsManager;

    public async Task ExecuteWork()
    {
        var correlationId = Guid.NewGuid();
        _logger.LogInformation("Executing GetExpiringWorkItemsCron Start: CorrelationId: {CorrelationId}", correlationId);

        var expringWorkItems = await _workItemsManager.GetExpiringWorkItemsAsync(correlationId: correlationId);

        _logger.LogInformation("Executing GetExpiringWorkItemsCron End: CorrelationId: {CorrelationId}", correlationId);
    }
}
