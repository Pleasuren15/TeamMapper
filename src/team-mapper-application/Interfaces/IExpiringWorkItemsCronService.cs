namespace team_mapper_application.Interfaces;

public interface IExpiringWorkItemsCronService
{
    Task ExecuteWork();
}
