using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSample.Framework
{
    public interface IEventStore
    {
        void Save(string aggregateTypeName,long id,int currentVersion,IReadOnlyList<IDomainEvent> events);
        IReadOnlyList<IDomainEvent> GetAll(string aggregateTypeName, long id);
    }
}
