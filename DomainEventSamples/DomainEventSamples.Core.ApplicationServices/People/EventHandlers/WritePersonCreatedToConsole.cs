using DomainEventSamples.Core.Events;
using DomainEventSamples.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace DomainEventSamples.Core.ApplicationServices.People.EventHandlers
{
    public class WritePersonCreatedToConsole:IDomainEventHandler<PersonCreated>
    {
        public Task Handel(PersonCreated domainEvent)
        {
            string str = JsonConvert.SerializeObject(domainEvent);
            Console.WriteLine(str);
            return Task.CompletedTask;
        }


    }
}
