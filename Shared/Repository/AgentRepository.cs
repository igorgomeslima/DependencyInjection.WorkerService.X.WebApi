using Shared.Generic;
using Shared.Entities;
using Shared.Interfaces;

namespace Shared.Repository
{
    public class AgentRepository : Repository<Agent>, IAgentRepository
    {
        public AgentRepository(IMongoDbContext context) : base(context)
        {
        }

        public void Igor()
        {
            throw new System.NotImplementedException();
        }
    }
}
