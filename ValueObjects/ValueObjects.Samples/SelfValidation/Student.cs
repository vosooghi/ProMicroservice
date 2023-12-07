using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjects.Samples.SelfValidation
{
    public enum StudentType
    {
       PhD, Master,Bacheloar
    }
    public class Student
    {
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public StudentType StudentType { get; set; }
        //Factory (static)
        public Student CreatePhdStudent(FirstName firstName, LastName lastName)
        {
            Student student = new Student { FirstName = firstName, LastName = lastName ,StudentType=StudentType.PhD};
            return student;
        }
    }

    
    public class FirstName
    {
        public string Value { get;private set; }
        public FirstName(string value) {
            //business rules
            if (value == null) throw new ValueObjectInvalidState("Invalid Firstname");
            if (value.Length<3) throw new ValueObjectInvalidState("Invalid Firstname");
            Value = value;
        }
    }
    public class LastName
    {
        public string Value { get; set; }
    }
}
