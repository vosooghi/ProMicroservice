using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySamples.Framework
{
    public interface IRepository<TAggregate> where TAggregate : AggregateRoot
    {
        TAggregate Get(long id);
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
