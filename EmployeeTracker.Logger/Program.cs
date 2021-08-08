using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeTracker.Logger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddSingleton(new RabbitMQService(hostContext.Configuration["RabbitMq:Host"],
                        hostContext.Configuration["RabbitMq:Username"], hostContext.Configuration["RabbitMq:Password"],
                        Convert.ToInt32(hostContext.Configuration["RabbitMq:Port"])));
                });
    }
}