using DomainEventSamples.Core.Events;
using DomainEventSamples.Framework;
using Newtonsoft.Json;

namespace DomainEventSamples.Core.ApplicationServices.People.EventHandlers
{
    public class WritePersonCreatedToFile:IDomainEventHandler<PersonCreated>
    {
        public  Task Handel(PersonCreated domainEvent)
        {
            string str = JsonConvert.SerializeObject(domainEvent);
            System.IO.File.WriteAllText("D:\\PersonCreated.txt", str);
            return Task.CompletedTask;
        }

    }
}
