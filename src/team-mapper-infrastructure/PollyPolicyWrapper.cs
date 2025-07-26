using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;
using team_mapper_infrastructure.Interfaces;

namespace team_mapper_application;

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
        Policy = new ResiliencePipelineBuilder()
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
                 }).Build();
    }
}
