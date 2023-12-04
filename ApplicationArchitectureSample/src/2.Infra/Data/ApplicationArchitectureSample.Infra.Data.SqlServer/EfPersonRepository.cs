using ApplicationArchitectureSample.Core.ApplicationServices;
using ApplicationArchitectureSample.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationArchitectureSample.Infra.Data.SqlServer
{
    public class EfPersonRepository : IPersonRepository
    {
        public AppArchContext _appArchContext { get; set; }

        public EfPersonRepository(AppArchContext appArchContext)
        {
            _appArchContext = appArchContext;
        }

        public void Add(Person person)
        {
            _appArchContext.People.Add(person);
            _appArchContext.SaveChanges();
        }

        public Person Get(int id)
        {
            Person person = _appArchContext.People.Include(x => x.PhoneNumbers).FirstOrDefault(w=>w.Id==id);
            return person;
        }

        public void Update(Person person)
        {
            _appArchContext.SaveChanges();
        }
    }
}
