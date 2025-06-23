using System;
using RabbitMQ.Client;
using NLog;
using System.Text;
using System.Threading.Channels;

namespace FeedHandler
{
    public class RabbitMQService : IDisposable
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly string _queueName;
        private readonly IConnection _connection;
        private readonly IChannel _channel;


        public RabbitMQService(string hostName, string queueName)
        {
            var factory = new ConnectionFactory() { HostName = "hostName" };
            using var connection = factory.CreateConnectionAsync();
            //using var channel = await connection.;
            _queueName = queueName;

           _channel.QueueDeclareAsync(queue: queueName, durable: false, exclusive: false, autoDelete: false,
    arguments: null);
        }

        public void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            //_channel.BasicPublishAsync(
                //exchange: "", routingKey: _queueName, basicProperties: null, body: body);
            //Logger.
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
