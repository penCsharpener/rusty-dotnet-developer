using System.Diagnostics;
using System.Security.Cryptography;

namespace BubbleSort;

internal class Program
{
    private static void Main(string[] args)
    {
        var array = Enumerable.Range(1, 10).Select(i => RandomNumberGenerator.GetInt32(1, 100001)).ToArray();

        var start = Stopwatch.GetTimestamp();

        Console.WriteLine(string.Join(", ", array));

        BubbleSort(array);

        Console.WriteLine("Ordered array");
        Console.WriteLine(string.Join(", ", array));

        Console.WriteLine(Stopwatch.GetElapsedTime(start));
    }

    private static void Print(int[] array)
    {
        var n = array.Length;
        for (var i = 0; i < n; i++)
        {
            Console.Write(array[i] + " ");
            Console.WriteLine();
        }
    }

    private static void BubbleSort(int[] array)
    {
        var arrayLength = array.Length;
        for (var i = 0; i < arrayLength - 1; i++)
        {
            for (var j = 0; j < arrayLength - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j + 1], array[j]) = (array[j], array[j + 1]);
                    Console.WriteLine($"i{i}j{j} " + string.Join(", ", array));
                }
            }
        }
    }
}
