using FizzBuzz.Abstractions;

namespace FizzBuzz.Services;

internal class NewLineFizzBuzz : IFizzBuzz
{
    public void Run()
    {
        for (var i = 1; i <= 100; i++)
        {
            var divisibleByThree = i % 3 == 0;
            var divisibleByFive = i % 5 == 0;

            if (divisibleByThree)
            {
                Console.Write("Fizz");
            }

            if (divisibleByFive)
            {
                Console.Write("Buzz");
            }

            if (!(divisibleByThree || divisibleByFive))
            {
                Console.Write(i);
            }

            Console.WriteLine();
        }
    }
}

