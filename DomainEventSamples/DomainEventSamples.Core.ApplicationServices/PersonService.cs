using DomainEventSamples.Framework;
using DomainEventSamples.Infra.DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEventSamples.Core.ApplicationServices
{
    public class PersonService
    {
        ILogger<PersonService> _logger;
        
        //type 3 dispatcher
        //private readonly IDomainEventDispatcher _domainEventDispatcher;

        public SampleContext Ctx { get; }
        public IServiceProvider _services { get; }

        public PersonService(SampleContext ctx, ILogger<PersonService> logger)//type 3 dispatcher ,IDomainEventDispatcher domainEventDispatcher)
        {
            Ctx = ctx;
            _logger = logger;

            //type 3 dispatcher
            //_domainEventDispatcher = domainEventDispatcher;
        }

        

        public async Task AddPerson(string firstName,string lastName)
        {
            Person person = new Person(firstName, lastName);
            /*
            foreach (var item in person.Events)
            {
                _logger.LogInformation("Event is {EventType}", item.GetType().FullName);
            }*/
            /* type 2 dispatcher
            foreach (dynamic @event in person.Events)
            {
                DispatchEvent(@event);
            }*/

            // type 3 dispatcher
            //await _domainEventDispatcher.Dispatch(person.Events);

            Ctx.People.AddAsync(person);
            Ctx.SaveChangesAsync();
        }
        public async Task SetFirstName(int id, string firstName) {
            var person = Ctx.People.FirstOrDefault(w => w.Id == id);

            /*
             * this is a type of Event handler, this method makes the application service complicated.
            foreach (var item in person.Events)
            {
                _logger.LogInformation("Event is {EventType}", item.GetType().FullName);
            }*/
            /* type 2 dispatcher
            foreach (dynamic @event in person.Events)
            {
                DispatchEvent(@event);
            }*/

            // type 3 dispatcher
            //await _domainEventDispatcher.Dispatch(person.Events);

            person.SetFirstName(firstName); 
            Ctx.SaveChangesAsync();
        }
        public async Task SetLastName(int id, string lastName) {
            var person = Ctx.People.FirstOrDefault(w => w.Id == id);
            /*type 1 dispatcher
            foreach (var item in person.Events)
            {
                _logger.LogInformation("Event is {EventType}", item.GetType().FullName);
            }*/
            /*type 2 dispatcher
            foreach (dynamic @event in person.Events)
            {
                DispatchEvent(@event);
            }*/

            //type 3 dispatcher
            //await _domainEventDispatcher.Dispatch(person.Events);

            person.SetLastName(lastName);
            Ctx.SaveChangesAsync();
        }

        //public Task DispatchEvent<TDomainEvent>(TDomainEvent @event) where TDomainEvent : IDomainEvent
        //{
        //    var handlers = _services.GetServices<IDomainEventHandler<TDomainEvent>>().ToList();
        //    foreach (var handler in handlers)
        //    {
        //        handler.Handel(@event);
        //    }
        //    return Task.CompletedTask;
        //}
    }
}
