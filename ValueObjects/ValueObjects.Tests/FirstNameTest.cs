using ValueObjects.Samples.SelfValidation;

namespace ValueObjects.Tests
{
    public class FirstNameTest
    {
        [Fact]
        public void Test1()
        {
            Assert.Throws<ValueObjectInvalidState>(() => new FirstName(""));
        }
    }
}