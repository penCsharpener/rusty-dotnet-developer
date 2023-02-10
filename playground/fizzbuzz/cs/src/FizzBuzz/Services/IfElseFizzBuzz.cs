using FizzBuzz.Abstractions;

namespace FizzBuzz.Services;
internal class IfElseFizzBuzz : IFizzBuzz
{
    public void Run()
    {
        for (var i = 1; i <= 100; i++)
        {
            var divisibleByThree = i % 3 == 0;
            var divisibleByFive = i % 5 == 0;

            if (divisibleByThree && divisibleByFive)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (divisibleByFive)
            {
                Console.WriteLine("Buzz");
            }
            else if (divisibleByThree)
            {
                Console.WriteLine("Fizz");
            }
            else
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
}
