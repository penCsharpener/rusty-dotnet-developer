using MentalMath.Core.Abstractions;
using MentalMath.Core.Models;

namespace MentalMath.Core.Services;

public sealed class MentalMathService : IMentalMathService
{
    private readonly IMathProblemValidator _problemValidator;
    private readonly IRandomService _randomService;

    public MentalMathService(IMathProblemValidator problemValidator, IRandomService randomService)
    {
        _problemValidator = problemValidator;
        _randomService = randomService;
    }

    public MathProblem GetNewMathProblem()
    {
        var mathProblem = new MathProblem();
        mathProblem.MathOperation = _randomService.GetMathOperation();

        while (!_problemValidator.IsMathProblemValid(mathProblem))
        {
            mathProblem.NumberOne = _randomService.GetRandomNumber();
            mathProblem.NumberTwo = _randomService.GetRandomNumber();
        }

        return mathProblem;
    }
}