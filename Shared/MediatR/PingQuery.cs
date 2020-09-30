using MediatR;
using System.Threading;
using Shared.Repository;
using System.Threading.Tasks;

namespace Shared.MediatR
{
    public class PingQuery : IRequest<string> { }

    public class PingQueryHandler : IRequestHandler<PingQuery, string>
    {
        readonly IMyRepository _myRepository;

        public PingQueryHandler(IMyRepository myRepository)
        {
            _myRepository = myRepository;
        }

        public Task<string> Handle(PingQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Pong");
        }
    }
}
