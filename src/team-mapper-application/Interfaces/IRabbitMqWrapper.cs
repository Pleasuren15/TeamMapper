using team_mapper_domain.Models;

namespace team_mapper_application.Interfaces;

public interface IRabbitMqWrapper
{
    Task PublishMessagesAsync(IEnumerable<ExpiringWorkItem> workItems);
}
