using System;

namespace Shared.Repository
{
    public interface IMyRepository
    {
        void Add();   
    }

    public class MyRepository : IMyRepository
    {
        public void Add()
        {
            throw new NotImplementedException();
        }
    }
}
