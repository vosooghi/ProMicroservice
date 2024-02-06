namespace CalculatorSample.Domain.Test
{
    public class PersonFactoryTest
    {
        [Fact]
        public void Can_Create_Student()
        {
            //Arrange
            Person p = PersonFactory.GetPersonOfType(PersonType.Student);
            //Act

            //Assert
            Assert.IsType<Student>(p);
        }
        [Fact]
        public void Can_Create_Person()
        {
            //Arrange
            Person p = PersonFactory.GetPersonOfType(PersonType.Student);
            //Act

            //Assert
            Assert.IsAssignableFrom<Person>(p);
        }
    }
}
