using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using RabbitMQ.Client.Events;

namespace EmployeeTracker.Logger
{
    public class Consumer
    {
        private readonly RabbitMQService _service;
        private readonly string _queueName = "errorqueue";

        public Consumer(string queueName, RabbitMQService service)
        {
            _service = service;
            _queueName = queueName;
            using (var connection = _service.RabbitMqConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new EventingBasicConsumer(channel);
                    // Received event'i sürekli listen modunda olacaktır.
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.Span;
                        var message = Encoding.UTF8.GetString(body);

                        Console.WriteLine("{0} isimli queue üzerinden gelen mesaj: \"{1}\"", queueName, message);
                    };
                    channel.BasicConsume(queueName, true, string.Empty, false, false, new Dictionary<string, object>(), consumer);
                    Console.ReadLine();
                }
            }
        }
    }
}