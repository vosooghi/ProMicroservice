using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelingBuildingBlock.EventSourcing
{
    public class Person
    {
        public int Id { get;private set; }
        public  string FirstName { get;private set; }
        public string LastName { get;private set; }

        public Person(List<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                //On(domainEvent);
            }
        }
        public Person(int id,string firstName,string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EventPublisher.Publish(new PersonCreated
            {
                 Id=id,
                 FirstName=firstName,
                 LastName=lastName
            }   );

            //Or

            var personCreated = new PersonCreated
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };
            EventPublisher.Publish(personCreated );
            On(personCreated );
        }
        public void SetFistName(string firstName)
        {
            FirstName = firstName;
            EventPublisher.Publish(new FirstNameUpdated
            {
                Id = Id,
                FirstName = firstName
            });
        }
        public void SetLastName(string lastName)
        {
            LastName = lastName;
            EventPublisher.Publish(new LastNameUpdated
            {
                Id = Id,
                LastName = lastName
            });
        }

        public void On(PersonCreated personCreated)
        {
            Id=personCreated.Id;
            FirstName=personCreated.FirstName;
            LastName=personCreated.LastName;
        }
        public void On(FirstNameUpdated firstNameUpdated)
        {
            Id = firstNameUpdated.Id;
            FirstName = firstNameUpdated.FirstName;
        }
        public void On(LastNameUpdated lastNameUpdated)
        {
            Id=lastNameUpdated.Id;
            LastName=lastNameUpdated.LastName;
        }
    }

    public interface IDomainEvent
    { }
    public class PersonCreated:IDomainEvent {

        public  int Id { get; set; }
        public  string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class FirstNameUpdated : IDomainEvent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
    public class LastNameUpdated : IDomainEvent
    {
        public int Id { get; set; }
        public string LastName { get; set; }
    }
}
