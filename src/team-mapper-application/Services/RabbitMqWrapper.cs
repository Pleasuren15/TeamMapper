using System.Text.Json;
using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using team_mapper_application.Interfaces;
using team_mapper_domain.Models;

namespace team_mapper_application.Services;

public class RabbitMqWrapper(IConfiguration configuration, ILogger<RabbitMqWrapper> logger) : IRabbitMqWrapper
{
    private readonly IConfiguration _configuration = configuration;
    private readonly ILogger<RabbitMqWrapper> _logger = logger;

    public async Task PublishMessagesAsync(IEnumerable<WorkItem> workItems)
    {
        _logger.LogInformation("RabbitMqWrapper PublishMessagesAsync Start: {@Time}, Count {@Count}", DateTimeOffset.Now, workItems.Count());

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
        using var connection = await connectionFactory.CreateConnectionAsync();

        using var channel = await connection.CreateChannelAsync();
        await channel.ExchangeDeclareAsync(exchange: exchangeName, ExchangeType.Direct);
        await channel.QueueDeclareAsync(queue: queueName, durable: true, exclusive: false, autoDelete: false);
        await channel.QueueBindAsync(queue: queueName, exchange: exchangeName, routingKey: routingKey);

        foreach (var item in workItems)
        {
            _logger.LogInformation("RabbitMqWrapper PublishingMessage: Message {@Message}", item);
            byte[] messageBody = System.Text.Encoding.UTF8.GetBytes(s: JsonSerializer.Serialize(item, new JsonSerializerOptions()
            {
                WriteIndented = true,
            }));
            await channel.BasicPublishAsync(exchangeName, routingKey: routingKey, messageBody);
        }

        _logger.LogInformation("RabbitMqWrapper PublishMessagesAsync Start: {@Time}, Count {@Count}", DateTimeOffset.Now, workItems.Count());
    }
}
