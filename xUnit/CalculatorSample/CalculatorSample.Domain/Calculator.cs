namespace CalculatorSample.Domain
{
    public class Calculator
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string FullName => $"{Firstname}, {Lastname}";
        public int Sum(int num1, int num2)
        {
            if (num1 < 0 || num2 < 0) throw new ArgumentOutOfRangeException();
            return num1 + num2;
        }
        public bool IsGreaterThanZero(int input) => input > 0;
    }
    public class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string FullName => $"{Firstname}, {Lastname}";
    }
    public class Teacher:Person
    { }
    public class Student:Person
    { }
    public class PersonFactory
    {
        public static Person GetPersonOfType(PersonType type)
        {
            return type == PersonType.Teacher ? new Teacher() : new Student();
        }
    }
    public enum PersonType
    {
        Student,
        Teacher
    }
}
