using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using TrainMe.DataBundler.Models.Common;

namespace TrainMe.DataBundler.Services.Common
{
    public interface IEventBusService
    {
        IConnection CreateChannel();
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
    }
}