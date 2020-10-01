using Shared.Entities;
using Shared.Interfaces;

namespace Shared.UoW
{
    public interface IUnitOfWork
    {
        IAgentRepository AgentRepository { get; }
        IRepository<Wallet> WalletRepository { get; }
        void Commit();
    }
}
