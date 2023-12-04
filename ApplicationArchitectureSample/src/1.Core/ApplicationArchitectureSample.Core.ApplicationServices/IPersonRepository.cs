using ApplicationArchitectureSample.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationArchitectureSample.Core.ApplicationServices
{
    public interface IPersonRepository
    {
        public void Add(Person person);
        public Person Get(int id);
        public void Update(Person person); 
    }
}
