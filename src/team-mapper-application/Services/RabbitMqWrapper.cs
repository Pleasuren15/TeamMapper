using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using team_mapper_application.Interfaces;

namespace team_mapper_application.Services;

public class RabbitMqWrapper(IConfiguration configuration) : IRabbitMqWrapper
{
    private readonly IConfiguration _configuration = configuration;

    public async Task PublishMessagesAsync()
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
        using var connection = await connectionFactory.CreateConnectionAsync();

        using var channel = await connection.CreateChannelAsync();
        await channel.ExchangeDeclareAsync(exchange: exchangeName, ExchangeType.Direct);
        await channel.QueueDeclareAsync(queue: queueName, durable: true, exclusive: false, autoDelete: false);
        await channel.QueueBindAsync(queue: queueName, exchange: exchangeName, routingKey: routingKey);

        byte[] messageBody = System.Text.Encoding.UTF8.GetBytes(s: "Hello, RabbitMQ!");
        await channel.BasicPublishAsync(exchangeName, routingKey, messageBody);
    }
}
