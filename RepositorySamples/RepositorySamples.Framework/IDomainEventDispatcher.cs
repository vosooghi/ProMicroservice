using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySamples.Framework
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(IEnumerable<IDomainEvent> events);
    }
}
