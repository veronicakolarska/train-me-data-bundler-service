using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using TrainMe.DataBundler.Models.Common;

namespace TrainMe.DataBundler.Services.Common
{
    public interface IEventBusService
    {
        IConnection CreateChannel();

        void SendMessage<T>(T message, string queueName);
    }

    public class EventBusService : IEventBusService
    {
        private readonly EventBusConfiguration eventBusConfiguration;
        public EventBusService(EventBusConfiguration eventBusConfiguration)
        {
            this.eventBusConfiguration = eventBusConfiguration;
        }
        public IConnection CreateChannel()
        {
            ConnectionFactory connection = new ConnectionFactory()
            {
                UserName = this.eventBusConfiguration.Username,
                Password = this.eventBusConfiguration.Password,
                HostName = this.eventBusConfiguration.HostName,
                Port = 5672
            };
            connection.DispatchConsumersAsync = true;

            var channel = connection.CreateConnection();
            return channel;
        }

        public void SendMessage<T>(T message, string queueName)
        {
            using var connection = this.CreateChannel();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queueName, exclusive: false);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: string.Empty, routingKey: queueName, body: body);
        }
    }
}