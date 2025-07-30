using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using team_mapper_application.Interfaces;

namespace team_mapper_application.Services;

public class ExpiringWorkItemsCronService(IServiceProvider serviceProvider) : IHostedService
{
    private readonly IConfiguration _configuration = serviceProvider.GetRequiredService<IConfiguration>();
    private readonly ILogger<ExpiringWorkItemsCronService> _logger = serviceProvider.GetRequiredService<ILogger<ExpiringWorkItemsCronService>>();
    Timer? _timer;

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

    private async void ExecuteWork(object state)
    {
        using var scope = serviceProvider.CreateScope();
        var scopedProcessingService =
            scope.ServiceProvider.GetRequiredService<IExpiringWorkItemsService>();

        await scopedProcessingService.ExecuteWork();
    }
}
