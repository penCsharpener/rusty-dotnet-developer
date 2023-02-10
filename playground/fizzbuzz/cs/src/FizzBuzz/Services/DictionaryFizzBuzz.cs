using FizzBuzz.Abstractions;

namespace FizzBuzz.Services;

internal class DictionaryFizzBuzz : IFizzBuzz
{
    public void Run()
    {
        for (var i = 1; i <= 100; i++)
        {
            var value = _combinations.Where(c => IsDivisableBy(i, c.Key)).FirstOrDefault(new KeyValuePair<int, string>(0, i.ToString())).Value;
            Console.WriteLine(value);
        }
    }

    private static readonly Dictionary<int, string> _combinations = new()
    {
        { 15, "FizzBuzz" },
        { 5, "Buzz" },
        { 3, "Fizz" },
    };

    private static bool IsDivisableBy(int i, int divider)
    {
        return i % divider == 0;
    }
}

