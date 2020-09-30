using MediatR;
using Shared.MediatR;
using Shared.Repository;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace WorkerService
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
                    services.AddMediatR(typeof(PingQuery));
                    services.AddScoped<IMyRepository, MyRepository>();

                    services.AddHostedService<Worker>();
                });
    }
}
