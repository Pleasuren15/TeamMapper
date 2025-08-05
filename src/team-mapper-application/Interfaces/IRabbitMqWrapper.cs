namespace team_mapper_application.Interfaces;

internal interface IRabbitMqWrapper
{
    Task PublishMessagesAsync();
}
