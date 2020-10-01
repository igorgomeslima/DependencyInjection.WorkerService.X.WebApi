using Shared.Generic;
using Shared.Entities;
using Shared.Interfaces;
using Shared.Repository;

namespace Shared.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IMongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        readonly IMongoDbContext _mongoDbContext;

        IAgentRepository _agent;
        IRepository<Wallet> _wallet;

        public IAgentRepository AgentRepository => _agent ?? (_agent = new AgentRepository(_mongoDbContext));
        public IRepository<Wallet> WalletRepository => _wallet ?? (_wallet = new Repository<Wallet>(_mongoDbContext));

        public void Commit()
        {
            _mongoDbContext.SaveChanges();
        }

    }
}
