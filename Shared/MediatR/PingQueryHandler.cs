using MediatR;
using System.Threading;
using Shared.Repository;
using System.Threading.Tasks;
using Shared.UoW;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared.MediatR
{
    public class PingQueryHandler : IRequestHandler<PingQuery, string>
    {
        //readonly IMyRepository _myRepository;

        //public PingQueryHandler(IMyRepository myRepository)
        //{
        //    _myRepository = myRepository;
        //}

        readonly IUnitOfWork _unitOfWork;

        public PingQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<string> Handle(PingQuery request, CancellationToken cancellationToken)
        {
            var list = new List<Wallet>();

            for (int i = 0; i < 100; i++)
            {
                var wallet = new Wallet { Id = i, Name = $"Test{i}" };

                //_unitOfWork.WalletRepository.Add(wallet);

                _unitOfWork.AgentRepository.Add(new Agent());
           
                list.Add(wallet);
            }

            _unitOfWork.WalletRepository.AddMany(list);

            _unitOfWork.Commit();

            return Task.FromResult("Pong");
        }
    }
}
