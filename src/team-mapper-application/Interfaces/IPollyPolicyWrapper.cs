namespace team_mapper_application.Interfaces;

public interface IPollyPolicyWrapper<T>
{
    Task<T> ExecuteAsync(Func<Task<T>> action);
}
