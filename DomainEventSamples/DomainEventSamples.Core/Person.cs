using DomainEventSamples.Framework;

namespace DomainEventSamples.Core
{
    public class Person:Entity
    {
        public string FirstName { get;private set; }
        public string LastName { get;private set;}
        public Person(string firstName,string lastName)
        {
            if(firstName == null)
                throw new ArgumentNullException(nameof(firstName));
            if(lastName == null) throw new ArgumentNullException( nameof(lastName));
            FirstName = firstName;
            LastName = lastName;
        }

        public void SetFirstName(string firstName)
        {
            if (firstName == null)
                throw new ArgumentNullException(nameof(firstName));
            FirstName = firstName;
        }
        public void SetLastName(string firstName)
        {
            if (firstName == null)
                throw new ArgumentNullException(nameof(firstName));
            FirstName = firstName;
        }
       
    }
}