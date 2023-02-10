using FizzBuzz.Abstractions;

namespace FizzBuzz.Services;

internal class SwitchExpressionFizzBuzz : IFizzBuzz
{
    public void Run()
    {
        for (var i = 1; i <= 100; i++)
        {
            Console.WriteLine(InternalFizzBuzz(i));
        }
    }

    private static string InternalFizzBuzz(int i)
    {
        return (i % 3, i % 5) switch
        {
            (0, 0) => "FizzBuzz",
            (0, _) => "Fizz",
            (_, 0) => "Buzz",
            (_, _) => i.ToString()
        };
    }
}

