using System;
using System.Text;
using Library.Web.Interfaces;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Library.Web.RabbitMq
{
    public class RabbitManager : IRabbitManager
    {
        private readonly RabbitOptions _options;
        public RabbitManager()
        {
            _options = new RabbitOptions();
        }
        public void Publish<T>(T message, string exchangeName, string exchangeType, string routeKey)
            where T : class
        {
            if (message == null)
                return;
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Password = "guest",
                UserName = "guest",
            };

            using var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchangeName, exchangeType, true, false, null);

            var sendBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            var properties = channel.CreateBasicProperties();

            //properties.Persistent = true;

            channel.BasicPublish(exchangeName, routeKey, properties, sendBytes);

        }
        
    }
}
