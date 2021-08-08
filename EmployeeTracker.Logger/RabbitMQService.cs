using RabbitMQ.Client;

namespace EmployeeTracker.Logger
{
    public class RabbitMQService
    {
        private readonly string _hostname = "localhost";
        private readonly string _userName = "guest";
        private readonly string _password = "guest";
        private readonly int _port = 5672;

        public RabbitMQService(string hostname, string userName, string password, int port)
        {
            _hostname = hostname;
            _password = password;
            _userName = userName;
            _port = port;
        }

        public IConnection RabbitMqConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName = _hostname,
                Password = _password,
                Port = _port,
                UserName = _userName
            };
            return connectionFactory.CreateConnection();
        }
    }
}