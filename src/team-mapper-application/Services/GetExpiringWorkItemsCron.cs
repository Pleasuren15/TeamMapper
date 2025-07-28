using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using team_mapper_application.Interfaces;

namespace team_mapper_application.Services;

public class GetExpiringWorkItemsCron(
    ILogger<GetExpiringWorkItemsCron> logger,
    IWorkItemsManager workItemsManager,
    IConfiguration configuration) : IHostedService, IDisposable
{
    private readonly ILogger<GetExpiringWorkItemsCron> _logger = logger;
    private readonly IWorkItemsManager _workItemsManager = workItemsManager;
    private readonly IConfiguration _configuration = configuration;

    private Timer? _timer;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var dueTimeInSeconds = Convert.ToInt32(_configuration["GetDueWorkItemsCron:DueTimeInSeconds"]);
        var periodInSeconds = Convert.ToInt32(_configuration["GetDueWorkItemsCron:PeriodInSeconds"]);

        _timer = new Timer(
            callback: ExecuteWork!,
            state: null,
            dueTime: TimeSpan.FromSeconds(dueTimeInSeconds),
            period: TimeSpan.FromSeconds(periodInSeconds));

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer!.Change(Timeout.Infinite, Convert.ToInt32(decimal.Zero));
        return Task.CompletedTask;
    }

    public void ExecuteWork(object state)
    {
        _logger.LogInformation("Cron Job Set up");
        var correlationId = Guid.NewGuid();
        var expringWorkItems = _workItemsManager.GetExpiringWorkItemsAsync(Guid.NewGuid()).GetAwaiter().GetResult();
    }

    public void Dispose() => _logger.LogInformation("Disposing GetDueWorkItemsCron Resources.");
}
