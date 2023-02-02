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
        private readonly EventBusConfiguration _configuration;
        public EventBusService(IOptions<EventBusConfiguration> options)
        {
            _configuration = options.Value;
        }
        public IConnection CreateChannel()
        {
            ConnectionFactory connection = new ConnectionFactory()
            {
                UserName = _configuration.Username,
                Password = _configuration.Password,
                HostName = _configuration.HostName
            };
            connection.DispatchConsumersAsync = true;

            var channel = connection.CreateConnection();
            return channel;
        }
    }
}