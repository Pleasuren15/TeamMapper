using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;
using team_mapper_application.Interfaces;

namespace team_mapper_application;

public class PollyPolicyWrapper<T> : IPollyPolicyWrapper<T> where T : class
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<PollyPolicyWrapper<T>> _logger;
    private readonly ResiliencePipeline<T> policy;

    public PollyPolicyWrapper(IConfiguration configuration, ILogger<PollyPolicyWrapper<T>> logger)
    {
        _configuration = configuration;
        _logger = logger;

        var maxRetryNumber = Convert.ToInt32(_configuration["PollyPolicy:AttemptNumber"]);
        policy = new ResiliencePipelineBuilder<T>()
                 .AddRetry(new Polly.Retry.RetryStrategyOptions<T>()
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
                 }).Build();
    }

    public async Task<T> ExecuteAsync(Func<Task<T>> action)
    {
        var result = await policy.ExecuteAsync<T>(async token =>
        {
            var results = await action();
            return results;
        }, CancellationToken.None);

        return result;
    }
}
