
namespace TDDSamples.FizzBuzzerDomain
{
    public class FizzBuzzer
    {
        public object GetValue(int input)
        {
            //1
            //return "1";

            //2
            //return input.ToString();

            //3
            //if (input == 3) { return "Fizz"; } else return input.ToString();

            //4
            //if (input == 3) return "Fizz"; if (input == 5) return "Buzz"; else return input.ToString();

            //5
            //if (input % 3 == 0) return "Fizz"; if (input == 5) return "Buzz"; else return input.ToString();

            //6, refactor
            //if (input % 3 == 0) return "Fizz"; if (input % 5 == 0) return "Buzz"; else return input.ToString();

            //7
            //if (input == 15) return "FizzBuzz"; if (input % 3 == 0) return "Fizz"; if (input % 5 == 0) return "Buzz"; else return input.ToString();

            //8 TDD Cycle Compeleted and our code works correctly regarding its functionality.
            /*if (input % 3 == 0 && input % 5 == 0) return "FizzBuzz";
            if (input % 3 == 0) return "Fizz";
            if (input % 5 == 0) return "Buzz";
            else return input.ToString();*/

            //9 Refactor code
            string output = string.Empty;
            if (input % 3 == 0) output = "Fizz";
            if (input % 5 == 0) output += "Buzz";
            if (string.IsNullOrEmpty(output)) output = input.ToString();
            return output;
        }
    }
}
