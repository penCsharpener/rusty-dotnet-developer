using MentalMath.Core.Abstractions;
using MentalMath.Core.Models;
using MentalMath.Core.Models.Enums;

namespace MentalMath.Core.Services;

public sealed class MathProblemValidator : IMathProblemValidator
{
    private readonly IOptionsService _optionsService;

    public MathProblemValidator(IOptionsService optionsService)
    {
        _optionsService = optionsService;
    }

    public bool IsMathProblemValid(MathProblem mathProblem)
    {
        if (mathProblem.MathOperation is null)
        {
            return false;
        }

        if (mathProblem.NumberTwo == 0 && mathProblem.NumberOne == 0)
        {
            return false;
        }

        var result = mathProblem.MathOperation switch
        {
            MathOperation.Addition => mathProblem.NumberOne + mathProblem.NumberTwo,
            MathOperation.Substraction => mathProblem.NumberOne - mathProblem.NumberTwo,
            MathOperation.Multiplication => mathProblem.NumberOne * mathProblem.NumberTwo,
            _ => 0
        };

        if (mathProblem.MathOperation == MathOperation.Multiplication)
        {
            if (mathProblem.NumberTwo == 1 || mathProblem.NumberOne == 1)
            {
                return false;
            }
        }

        if (mathProblem.MathOperation == MathOperation.Substraction)
        {
            if (mathProblem.NumberTwo > mathProblem.NumberOne)
            {
                return false;
            }
        }

        if (mathProblem.MathOperation == MathOperation.Division)
        {
            if (mathProblem.NumberTwo == 0)
            {
                return false;
            }

            if (mathProblem.NumberOne == mathProblem.NumberTwo)
            {
                return false;
            }

            if (mathProblem.NumberTwo == 1)
            {
                return false;
            }

            if (mathProblem.NumberTwo > mathProblem.NumberOne)
            {
                return false;
            }

            var divisionResult = mathProblem.NumberOne / (decimal) mathProblem.NumberTwo;

            if (divisionResult % 1 != 0)
            {
                return false;
            }

            result = (int) divisionResult;
        }

        if (result > _optionsService.Options.HighestAvailableNumber)
        {
            return false;
        }

        mathProblem.Result = result;

        if (mathProblem.Result > _optionsService.Options.HighestAvailableNumber)
        {
            return false;
        }

        if (!_optionsService.Options.AllowNegativeResults && mathProblem.Result < 0)
        {
            return false;
        }

        return true;
    }
}