using MediatR;
using Shared.MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        readonly IMediator _mediator;
        
        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return await _mediator.Send(new PingQuery());
        }
    }
}
