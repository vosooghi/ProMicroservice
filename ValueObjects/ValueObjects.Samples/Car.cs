using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjects.Samples
{
    public class Car
    {
        public int Id { get;  set; }
        public Meter Hight { get;  set; }
        public Car( int id,Meter height) {
        Id= id;
            Hight= height;
        }
         public Car() { }
    }

    public class Person
    {
        public int Id { get; set; }
        public Meter Hight { get; set; }

    }
}
