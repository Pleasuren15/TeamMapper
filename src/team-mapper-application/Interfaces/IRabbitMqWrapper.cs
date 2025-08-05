using team_mapper_domain.Models;

namespace team_mapper_application.Interfaces;

internal interface IRabbitMqWrapper
{
    Task PublishMessagesAsync(List<WorkItem>  workItems);
}
