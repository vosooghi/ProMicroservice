using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace CalculatorSample.Domain.Test
{
    //Method 3, Test Data from file
    public class TestDataProviderAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var result = new List<object[]>
            {
                new object[] { 1,true},
                new object[] { -1,false},
            };
            return result;
        }
    }

    //Method 2
    public class TestDataProvider
    {
        public static List<object[]> GetDataDrivenValues()
        {
            var result = new List<object[]>
            {
                new object[] { 1,true},
                new object[] { -1,false},
            };
            return result;
        }
    }
    public class CalculatorTest
    {
        public readonly ITestOutputHelper _testOutputHelper;

        public CalculatorTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        [Fact]
        [Trait("Group","G1")]
        public void Get_True_When_Input_Is_Greater_Than_Zero()
        {
            //Arrange
            Calculator calculator = new Calculator();
            //Act
            var result = calculator.IsGreaterThanZero(1);
            //Assert
            _testOutputHelper.WriteLine("Test executed.");
            Assert.True(result);
        }
        [Fact]
        [Trait("Group", "G1")]
        public void Get_True_When_Input_Is_Less_Than_Zero()
        {
            //Arrange
            Calculator calculator = new Calculator();
            //Act
            var result = calculator.IsGreaterThanZero(-1);
            //Assert
            _testOutputHelper.WriteLine("Test executed.");
            Assert.True(!result);
        }
        [Theory]
        //Method 1
        //[InlineData(1,true)]
        //[InlineData(-1, false)]
        //Method 2
        //[MemberData(nameof(TestDataProvider.GetDataDrivenValues),MemberType =typeof(TestDataProvider))]
        //Method 3
        [TestDataProvider]
        public void Data_Driven_Test(int input, bool excpetedReslt)
        {
            //Arrange
            Calculator calculator = new Calculator();
            //Act
            var result = calculator.IsGreaterThanZero(input);
            //Assert
            _testOutputHelper.WriteLine("DDT Test executed.");
            Assert.Equal(excpetedReslt,result);
        }

        [Fact]
        [Trait("Group", "G1")]
        public void Sum_Of_One_And_Three()
        {
            //Arrange
            Calculator calculator = new Calculator();
            //Act
            var result = calculator.Sum(1, 3);
            //Assert
            Assert.Equal(4,result);

        }
        [Fact(Skip ="Nothing")]
        [Trait("Group", "G2")]
        public void Some_Of_Two_Number_Should_Be()
        {

        }
        [Fact]
        [Trait("Group", "G2")]
        public void Fullname_Check_Concatenation()
        {
            //Arrange
            Calculator calculator = new Calculator();
            calculator.Firstname = "Abbas";
            calculator.Lastname = "Vosoughi";
            //Act

            //Assert
            Assert.Contains(", ", calculator.FullName);
        }

        [Fact]
        [Trait("Group", "G3")]
        public void Throw_Correct_Exception()
        {
            //Arrange
            Calculator calculator = new Calculator();
            //Act
            //var result = calculator.Sum(-1, 2);
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=>calculator.Sum(-1,2));
        }
    }
} 