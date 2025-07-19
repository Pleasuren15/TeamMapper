namespace team_mapper_infrastructure.RepositoryPattern
{
    public class TaskService(IRepository<team_mapper_domain.Models.Task> taskRepository) : ITaskService
    {
        private readonly IRepository<team_mapper_domain.Models.Task> _taskRepository = taskRepository;

        public async Task<IEnumerable<team_mapper_domain.Models.Task>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllAsync();
        }
    }
}
