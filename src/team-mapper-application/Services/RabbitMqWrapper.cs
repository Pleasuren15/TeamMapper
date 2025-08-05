using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using team_mapper_application.Interfaces;

namespace team_mapper_application.Services;

public class RabbitMqWrapper(IConfiguration configuration) : IRabbitMqWrapper
{
    private readonly IConfiguration _configuration = configuration;

    public Task PublishMessagesAsync()
    {
        var hostConnectionString = Guard.Against.NullOrEmpty(input: _configuration.GetConnectionString("RabbitMqHost"));
        var clintentProvidedName = Guard.Against.NullOrEmpty(input: _configuration["RabbitMq:ClientProvideName"]);
        var exchangeName = Guard.Against.NullOrEmpty(input: _configuration["RabbitMq:ExchangeName"]);
        var queueName = Guard.Against.NullOrEmpty(input: _configuration["RabbitMq:QueueName"]);
        var routingKey = Guard.Against.NullOrEmpty(input: _configuration["RabbitMq:RoutingKey"]);

        var connectionFactory = new ConnectionFactory()
        {
            Uri = new Uri(hostConnectionString!),
            ClientProvidedName = clintentProvidedName
        };

        return Task.CompletedTask;
    }
}
