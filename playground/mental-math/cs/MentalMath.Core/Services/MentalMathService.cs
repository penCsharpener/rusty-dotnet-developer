using MentalMath.Core.Abstractions;
using MentalMath.Core.Models;
using MentalMath.Core.Models.Enums;
using Microsoft.Extensions.Logging;

namespace MentalMath.Core.Services;

public sealed class MentalMathService : IMentalMathService
{
    private readonly ILogger<MentalMathService> _logger;
    private readonly IMathProblemValidator _problemValidator;
    private readonly IRandomService _randomService;

    public MentalMathService(IMathProblemValidator problemValidator, IRandomService randomService, ILogger<MentalMathService> logger)
    {
        _problemValidator = problemValidator;
        _randomService = randomService;
        _logger = logger;
    }

    public MathProblem GetNewMathProblem()
    {
        var mathProblem = new MathProblem
        {
            MathOperation = _randomService.GetMathOperation()
        };

        while (!_problemValidator.IsMathProblemValid(mathProblem))
        {
            _logger.LogInformation(mathProblem.ToString());
            GenerateRandomNumbers(mathProblem);
        }

        return mathProblem;
    }

    private void GenerateRandomNumbers(MathProblem mathProblem)
    {
        if (mathProblem.MathOperation == MathOperation.Addition)
        {
            var numberOne = _randomService.GetRandomNumber();
            var numberTwo = _randomService.GetRandomNumber();

            var largest = new[] { numberOne, numberTwo }.Max();
            var smallest = new[] { numberOne, numberTwo }.Min();

            var numberThree = largest - smallest;

            mathProblem.NumberOne = smallest;
            mathProblem.NumberTwo = numberThree;
            mathProblem.Result = largest;
        }
        else if (mathProblem.MathOperation == MathOperation.Substraction)
        {
            var numberOne = _randomService.GetRandomNumber();
            var numberTwo = _randomService.GetRandomNumber();

            var largest = new[] { numberOne, numberTwo }.Max();
            var smallest = new[] { numberOne, numberTwo }.Min();

            var numberThree = largest - smallest;

            mathProblem.NumberOne = largest;
            mathProblem.NumberTwo = smallest;
            mathProblem.Result = numberThree;
        }
        else if (mathProblem.MathOperation == MathOperation.Multiplication)
        {
            var numberOne = _randomService.GetRandomNumberSquared();
            var numberTwo = _randomService.GetRandomNumberSquared();

            mathProblem.NumberOne = numberOne;
            mathProblem.NumberTwo = numberTwo;
            mathProblem.Result = numberOne * numberTwo;
        }
        else if (mathProblem.MathOperation == MathOperation.Division)
        {
            var numberOne = _randomService.GetRandomNumberSquared();
            var numberTwo = _randomService.GetRandomNumberSquared();

            mathProblem.NumberOne = numberOne * numberTwo;
            mathProblem.NumberTwo = numberTwo;
            mathProblem.Result = numberOne;
        }
        else
        {
            mathProblem.NumberOne = _randomService.GetRandomNumber();
            mathProblem.NumberTwo = _randomService.GetRandomNumber();
        }
    }
}