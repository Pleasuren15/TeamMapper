namespace team_mapper_infrastructure.RepositoryPattern;

public interface ITaskService
{
    Task<IEnumerable<team_mapper_domain.Models.Task>> GetAllTasksAsync();
}
