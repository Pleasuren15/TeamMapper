using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using team_mapper_application.Interfaces;

namespace team_mapper_application.Services;

public class RabbitMqWrapper(IConfiguration configuration) : IRabbitMqWrapper
{
    private readonly IConfiguration _configuration = configuration;

    public Task PublishMessagesAsync()
    {
        var hostConnectionString = _configuration.GetConnectionString("RabbitMqHost");
        var clintentProvidedName = _configuration["RabbitMq:ClientProvideName"];
        var exchangeName = _configuration["RabbitMq:ExchangeName"];
        var queueName = _configuration["RabbitMq:QueueName"];
        var routingKey = _configuration["RabbitMq:RoutingKey"];

        var connectionFactory = new ConnectionFactory()
        {
            Uri = new Uri(hostConnectionString!),
            ClientProvidedName = clintentProvidedName
        };

        return Task.CompletedTask''
    }
}
