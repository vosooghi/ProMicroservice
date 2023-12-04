using ApplicationArchitectureSample.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationArchitectureSample.Core.ApplicationServices
{
    public class PersonApplicationService
    {
        private IPersonRepository _personRepository;

        public PersonApplicationService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
       
        public void AddPerson(CreatePersonInputDto dto)
        {
            PhoneNumber phoneNumber = new PhoneNumber(dto.PhoneNumber);
            Person person = new Person(dto.FirstName,dto.LastName,phoneNumber);
            _personRepository.Add(person);
        }

        public void AddNumberToPerson(AddNumberToPersonDto dto)
        {
            var person = _personRepository.Get(dto.PersonId);
            if(person == null) { throw new ApplicationException($"Person Not found with Id{dto.PersonId}"); }
            PhoneNumber phoneNumber = new PhoneNumber(dto.Number);
            person.AddPhoneNumber(phoneNumber);
            _personRepository.Update(person);
        }
    }
}
