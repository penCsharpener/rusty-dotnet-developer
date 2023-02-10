using FizzBuzz.Abstractions;
using FizzBuzz.Services;

namespace FizzBuzz;

internal class Program
{
    private static IFizzBuzz? _fizzBuzz;

    private static void Main(string[] args)
    {
        _fizzBuzz = new DictionaryFizzBuzz();

        _fizzBuzz.Run();
    }
}
