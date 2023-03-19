using MentalMath.Core.Models;

namespace MentalMath.Core.Abstractions;

public interface IMathProblemValidator
{
    bool IsMathProblemValid(MathProblem mathProblem);
}