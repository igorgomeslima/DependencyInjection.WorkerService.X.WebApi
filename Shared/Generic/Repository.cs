using MongoDB.Driver;
using Shared.Interfaces;
using System.Collections.Generic;

namespace Shared.Generic
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoDbContext Context;
        protected IMongoCollection<TEntity> DbSet;

        public Repository(IMongoDbContext context)
        {
            Context = context;
            ConfigDbSet();
        }

        public virtual void Add(TEntity obj)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        public virtual void AddMany(IEnumerable<TEntity> obj)
        {
            //ConfigDbSet();
            Context.AddCommand(() => DbSet.InsertManyAsync(obj));
        }

        private void ConfigDbSet()
        {
            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
