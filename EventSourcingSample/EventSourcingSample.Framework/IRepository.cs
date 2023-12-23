using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSample.Framework
{
    public interface IRepository<TAggregate> where TAggregate : AggregateRoot
    {
        TAggregate Get(long id);
        void Save(TAggregate aggregate);
    }
}
