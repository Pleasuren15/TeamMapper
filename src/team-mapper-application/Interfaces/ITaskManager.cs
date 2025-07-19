namespace team_mapper_application.Interfaces
{
    public interface ITaskManager
    {
        Task<IEnumerable<team_mapper_domain.Models.Task>> GetAllTasksAsync(Guid correlationId);
    }
}
