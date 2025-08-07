using Microsoft.Extensions.Logging;
using team_mapper_application.Interfaces;
using team_mapper_domain.Models;

namespace team_mapper_application.Services;

public class ExpiringWorkItemsService(
    ILogger<ExpiringWorkItemsCronService> logger,
    IWorkItemsManager workItemsManager,
    IRabbitMqWrapper rabbitMqWrapper) : IExpiringWorkItemsService
{
    private readonly ILogger<ExpiringWorkItemsCronService> _logger = logger;
    private readonly IRabbitMqWrapper _rabbitMqWrapper = rabbitMqWrapper;
    private readonly IWorkItemsManager _workItemsManager = workItemsManager;

    public async Task ExecuteWorkAsync()
    {
        var correlationId = Guid.NewGuid();
        _logger.LogInformation("Executing GetExpiringWorkItemsCron Start: CorrelationId: {CorrelationId}", correlationId);

        var expringWorkItems = new List<ExpiringWorkItem>();
        foreach (var workItem in await _workItemsManager.GetExpiringWorkItemsAsync(correlationId: correlationId))
        {
            expringWorkItems.Add(new ExpiringWorkItem
            {
                ExpiringWorkItemId = Guid.NewGuid(),
                EndDate = workItem.EndDate,
                IsNotificationSent = false,
                WorkItemId = workItem.WorkItemId,
                WorkItem = workItem
            });
        }

        await _rabbitMqWrapper.PublishMessagesAsync(workItems: expringWorkItems);

        _logger.LogInformation("Executing GetExpiringWorkItemsCron End: CorrelationId: {CorrelationId}", correlationId);
    }
}
