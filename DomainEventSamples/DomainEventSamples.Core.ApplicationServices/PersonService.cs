using DomainEventSamples.Infra.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEventSamples.Core.ApplicationServices
{
    public class PersonService
    {
        public PersonService(SampleContext ctx)
        {
            Ctx = ctx;
        }

        public SampleContext Ctx { get; }

        public async Task AddPerson(string firstName,string lastName)
        {
            Person person = new Person(firstName, lastName);
            Ctx.People.AddAsync(person);
            Ctx.SaveChangesAsync();
        }
        public async Task SetFirstName(int id, string firstName) {
            var person = Ctx.People.FirstOrDefault(w => w.Id == id);
            person.SetFirstName(firstName); 
            Ctx.SaveChangesAsync();
        }
        public async Task SetLastName(int id, string lastName) {
            var person = Ctx.People.FirstOrDefault(w => w.Id == id);
            person.SetLastName(lastName);
            Ctx.SaveChangesAsync();
        }
    }
}
