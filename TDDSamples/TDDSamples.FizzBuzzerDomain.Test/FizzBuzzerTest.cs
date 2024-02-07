namespace TDDSamples.FizzBuzzerDomain.Test
{
    public class FizzBuzzerTest
    {
        /*
        [Fact]
        public void FizzBuzzer_Returns_One_When_Receives_One()
        {//iterate 1
            //Arrange
            int input = 1;
            string expected = "1";

            FizzBuzzer fizzBuzzer = new FizzBuzzer();
            //Act
            var result = fizzBuzzer.GetValue(input);
            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void FizzBuzzer_Returns_Two_When_Receives_Two()
        {//iterate 2
            //Arrange
            int input = 2;
            string expected = "2";

            FizzBuzzer fizzBuzzer = new FizzBuzzer();
            //Act
            var result = fizzBuzzer.GetValue(input);
            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void FizzBuzzer_Returns_Fizz_When_Receives_Three()
        {//iterate 3
            //Arrange
            int input = 3;
            string expected = "Fizz";

            FizzBuzzer fizzBuzzer = new FizzBuzzer();
            //Act
            var result = fizzBuzzer.GetValue(input);
            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void FizzBuzzer_Returns_Four_When_Receives_Four()
        {//iterate 4
            //Arrange
            int input = 4;
            string expected = "4";

            FizzBuzzer fizzBuzzer = new FizzBuzzer();
            //Act
            var result = fizzBuzzer.GetValue(input);
            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void FizzBuzzer_Returns_Buzz_When_Receives_Five()
        {//iterate 4
            //Arrange
            int input = 5;
            string expected = "Buzz";

            FizzBuzzer fizzBuzzer = new FizzBuzzer();
            //Act
            var result = fizzBuzzer.GetValue(input);
            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void FizzBuzzer_Returns_Fizz_When_Receives_Six()
        {//iterate 5
            //Arrange
            int input = 6;
            string expected = "Fizz";

            FizzBuzzer fizzBuzzer = new FizzBuzzer();
            //Act
            var result = fizzBuzzer.GetValue(input);
            //Assert
            Assert.Equal(expected, result);
        }
        */

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(11)]
        [InlineData(13)]
        [InlineData(14)]
        [InlineData(16)]
        [InlineData(17)]
        [InlineData(19)]
        [InlineData(22)]
        [InlineData(23)]
        [InlineData(26)]
        [InlineData(28)]
        [InlineData(29)]
        public void FizzBuzzer_Returns_Input_When_Receives_Simple_Number(int input)
        {//iterate 6, Refactoring
            //Arrange
            string expected = input.ToString();

            FizzBuzzer fizzBuzzer = new FizzBuzzer();
            //Act
            var result = fizzBuzzer.GetValue(input);
            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(18)]
        [InlineData(21)]
        [InlineData(24)]
        [InlineData(27)]
        public void FizzBuzzer_Returns_Fizz_When_Receives_Fizz_Number(int input)
        {//iterate 6, refactoring
            //Arrange
            string expected = "Fizz";

            FizzBuzzer fizzBuzzer = new FizzBuzzer();
            //Act
            var result = fizzBuzzer.GetValue(input);
            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(25)]
        public void FizzBuzzer_Returns_Buzz_When_Receives_Divisible_By_Five(int input)
        {//iterate 6, refactoring
            //Arrange
            string expected = "Buzz";

            FizzBuzzer fizzBuzzer = new FizzBuzzer();
            //Act
            var result = fizzBuzzer.GetValue(input);
            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        public void FizzBuzzer_Returns_Buzz_When_Receives_Divisible_By_Three_And_Five(int input)
        {//iterate 7, refactoring
            //Arrange
            string expected = "FizzBuzz";

            FizzBuzzer fizzBuzzer = new FizzBuzzer();
            //Act
            var result = fizzBuzzer.GetValue(input);
            //Assert
            Assert.Equal(expected, result);
        }
    }
}