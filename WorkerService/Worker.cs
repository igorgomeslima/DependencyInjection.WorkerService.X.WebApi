using MediatR;
using Shared.MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        readonly IMediator _mediator;
        readonly ILogger<Worker> _logger;
        
        public Worker(ILogger<Worker> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var result = await _mediator.Send(new PingQuery());

                _logger.LogInformation("MediatR result: {result}", result);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
