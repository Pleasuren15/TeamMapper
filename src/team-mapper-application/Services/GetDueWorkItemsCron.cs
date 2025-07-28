using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace team_mapper_application.Services;

public class GetDueWorkItemsCron(ILogger<GetDueWorkItemsCron> logger) : IHostedService, IDisposable
{
    private Timer _timer;
    private ILogger<GetDueWorkItemsCron> _logger = logger;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(ExecuteWork, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(5));
        throw new NotImplementedException();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void ExecuteWork(object state)
    {
        _logger.LogInformation("Cron Job Set up");
    }

    public void Dispose() => _logger.LogInformation("Disposing GetDueWorkItemsCron Resources.");
}
