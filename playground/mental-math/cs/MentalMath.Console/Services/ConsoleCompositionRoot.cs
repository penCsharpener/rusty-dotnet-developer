using MentalMath.Core.Abstractions;
using MentalMath.Core.Models;
using MentalMath.Core.Models.Enums;
using static System.Console;

namespace MentalMath.Console.Services;

public class ConsoleCompositionRoot
{
    private readonly IMentalMathService _mentalMathService;
    private readonly IOptionsService _optionsService;
    private readonly IList<Answer> _userAnswers = new List<Answer>();

    public ConsoleCompositionRoot(IOptionsService optionsService, IMentalMathService mentalMathService)
    {
        _optionsService = optionsService;
        _mentalMathService = mentalMathService;
    }

    public void GetOptions()
    {
        WriteLine("Let's define the rules:");
        WriteLine("Do you want allow negative numbers in the results? (y/N)");
        var key = ReadKey();

        if (key.KeyChar is 'y' or 'Y')
        {
            _optionsService.Options.AllowNegativeResults = true;

            WriteLine();
            WriteLine("Got it! No negative results desired.");
        }

        WriteLine("How long do you want to play? Default is 5 minutes! (60s/ 5m / 1h)");
        var length = ReadLine();

        var timespan = length switch
        {
            null => TimeSpan.FromMinutes(5),
            [.. var amount, 's'] => TimeSpan.FromSeconds(int.Parse(amount)),
            [.. var amount, 'm'] => TimeSpan.FromMinutes(int.Parse(amount)),
            [.. var amount, 'h'] => TimeSpan.FromHours(int.Parse(amount)),
            _ => TimeSpan.FromMinutes(5)
        };

        _optionsService.Options.PlayTime = timespan;

        WriteLine();
        WriteLine($"Playing for {timespan}");

        WriteLine("Which math operations do you want? Type the numbers (134, 12, 4). Default is all of them.");
        WriteLine($"1 {MathOperation.Addition}");
        WriteLine($"2 {MathOperation.Substraction}");
        WriteLine($"3 {MathOperation.Multiplication}");
        WriteLine($"4 {MathOperation.Division}");
        WriteLine();

        var operations = ReadLine()?.ToCharArray().Select(c => int.Parse(c.ToString())).Sum();

        _optionsService.Options.MathOperations = operations is null or 0 ? MathOperation.Addition | MathOperation.Substraction | MathOperation.Multiplication | MathOperation.Division : (MathOperation) operations.Value;

        WriteLine("How large should the highest available number be? (20: 9+11, 4*5, 20-11=9, 20/5=4");
        int.TryParse(ReadLine(), out var highestNumber);

        _optionsService.Options.HighestAvailableNumber = highestNumber == 0 ? 100 : highestNumber;

        WriteLine();
        WriteLine();
    }

    public void GreetUser()
    {
        WriteLine("Welcome to Mental Math");
        WriteLine("Press ENTER to start.");
        ReadLine();
    }

    public void Play()
    {
        var endGame = DateTime.Now.Add(_optionsService.Options.PlayTime);

        while (endGame > DateTime.Now)
        {
            var mathProblem = _mentalMathService.GetNewMathProblem();

            WriteLine();
            WriteLine($"{mathProblem.NumberOne} {mathProblem.MathOperationSymbol} {mathProblem.NumberTwo} = ___ ?");
            var userAnswer = new Answer(mathProblem);

            int.TryParse(ReadLine(), out var answer);
            userAnswer.SetUserResult(answer);

            if (userAnswer.IsCorrect)
            {
                WriteLine("Correct!");
            }
            else
            {
                WriteLine($"Wrong! => Correct answer: {mathProblem.Result}");
            }

            _userAnswers.Add(userAnswer);
        }

        WriteLine();
        WriteLine($"Time is up! Congratulations! You have solved {_userAnswers.Count(a => a.IsCorrect)} of {_userAnswers.Count} correctly.");
    }
}