using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;
using team_mapper_infrastructure.Interfaces;

namespace team_mapper_infrastructure;

public class PollyPolicyWrapper : IPollyPolicyWrapper
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<PollyPolicyWrapper> _logger;
    public ResiliencePipeline Policy { get; set; }

    public PollyPolicyWrapper(IConfiguration configuration, ILogger<PollyPolicyWrapper> logger)
    {
        _configuration = configuration;
        _logger = logger;

        var maxRetryNumber = Convert.ToInt32(_configuration["PollyPolicy:AttemptNumber"]);
        Policy = CreateResiliencePipeline();
    }

    public async Task<T> ExecuteWithPollyRetryPolicyAsync<E, T>(Func<Task<T>> func) where E : Exception
    {
        var results = await Policy.ExecuteAsync(async (CancellationToken) => await func());
        return results;
    }

    private ResiliencePipeline CreateResiliencePipeline()
    {
        var maxRetryNumber = Convert.ToInt32(_configuration["PollyPolicy:AttemptNumber"]);
        return new ResiliencePipelineBuilder()
            .AddRetry(new Polly.Retry.RetryStrategyOptions()
            {
                MaxRetryAttempts = maxRetryNumber,
                Delay = TimeSpan.Zero,
                OnRetry = retryArguments =>
                {
                    _logger.LogWarning(
                        "Retrying operation {@Operation}, attempt {@Attempt})",
                        retryArguments.Context.OperationKey,
                        retryArguments.AttemptNumber);
                    return ValueTask.CompletedTask;
                }
            })
            .Build();
    }
}
