using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelingBuildingBlock.Entities
{
    public class Person
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get;private set; }

        public Person( int id,string firstName,string lastName)
        {
            if (firstName == null) throw new ArgumentNullException(nameof(firstName));
            if (lastName == null) throw new ArgumentNullException(nameof(lastName));
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        //Behaviours for chaning state. Id doesn't change.
        public void SetFirstName( string firstName )
        {
            if (firstName == null) throw new ArgumentNullException(nameof(firstName));
            FirstName = firstName;
        }
        public void SetLastName( string lastName )
        {
            if (lastName == null) throw new ArgumentNullException(nameof(lastName));
            LastName = lastName;
        }

        //tho entites are equal when their id fields are the same.
        //We have to repeat this peice of code for all entities, so it seems that we need a base class...
        public override bool Equals(object? obj)
        {
            var other = obj as Person;
            if(other == null) return false;
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
