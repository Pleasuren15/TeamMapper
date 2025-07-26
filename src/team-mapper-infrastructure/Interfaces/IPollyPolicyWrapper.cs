using Polly;

namespace team_mapper_infrastructure.Interfaces;

public interface IPollyPolicyWrapper
{

    Task<T> ExecuteWithPollyRetryPolicyAsync<E, T>(Func<Task<T>> func) where E : Exception;
}
