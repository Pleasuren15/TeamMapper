using Ardalis.GuardClauses;
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
        var dueTimeInSeconds = Convert.ToInt32(Guard.Against.NullOrEmpty(_configuration["GetDueWorkItemsCron:DueTimeInSeconds"]));
        var periodInSeconds = Convert.ToInt32(Guard.Against.NullOrEmpty(_configuration["GetDueWorkItemsCron:PeriodInSeconds"]));
        _logger.LogInformation("StartAsync ExpiringWorkItemsCronService Start: {@time}", DateTimeOffset.Now);

        _timer = new Timer(
            callback: ExecuteWork!,
            state: null,
            dueTime: TimeSpan.FromSeconds(dueTimeInSeconds),
            period: TimeSpan.FromSeconds(periodInSeconds));

        _logger.LogInformation("StartAsync ExpiringWorkItemsCronService End: {@time}", DateTimeOffset.Now);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("StopAsync ExpiringWorkItemsCronService Start: {@time}", DateTimeOffset.Now);
        _timer!.Change(Timeout.Infinite, Convert.ToInt32(decimal.Zero));
        _logger.LogInformation("StopAsync ExpiringWorkItemsCronService End: {@time}", DateTimeOffset.Now);
        return Task.CompletedTask;
    }

    private async void ExecuteWork(object state)
    {
        _logger.LogInformation("ExpiringWorkItemsCronService Start: {@time}", DateTimeOffset.Now);
        using var scope = serviceProvider.CreateScope();
        var scopedProcessingService =
            scope.ServiceProvider.GetRequiredService<IExpiringWorkItemsService>();

        await scopedProcessingService.ExecuteWork();
        _logger.LogInformation("ExpiringWorkItemsCronService End: {@time}", DateTimeOffset.Now);
    }
}
