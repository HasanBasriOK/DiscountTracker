using System;
using System.Text;
using DiscountTracker.Entities;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace DiscountTracker.Common.QueueManagement.RabbitMq
{
    public class RabbitMqManager : IRabbitMqManager
    {
        private readonly IOptions<RabbitMqConfiguration> _rabbitMqConfiguration;
        private static ConnectionFactory _connectionFactory;
        private static IConnection _connection;
        public RabbitMqManager(IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
        {
            _rabbitMqConfiguration = rabbitMqConfiguration;

            if (_connectionFactory == null)
            {
                _connectionFactory = new ConnectionFactory();
                _connectionFactory.HostName = _rabbitMqConfiguration.Value.Host;
                _connectionFactory.Port = _rabbitMqConfiguration.Value.Port;
                _connectionFactory.UserName = _rabbitMqConfiguration.Value.Username;
                _connectionFactory.Password = _rabbitMqConfiguration.Value.Password;

            }
        }
        public bool SendDataToQueue(QueueType queueType, object data)
        {
            var result = true;
            try
            {
                if (_connection == null)
                    _connection = _connectionFactory.CreateConnection();

                var channel = _connection.CreateModel();
                channel.QueueDeclare(queueType.ToString(), false, false, false, null);
                var messageJson = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                var message = Encoding.UTF8.GetBytes(messageJson);

                channel.BasicPublish(exchange: String.Empty,routingKey: queueType.ToString(),basicProperties: null,body: message);
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
    }
}
