using MentalMath.Core.Models;

namespace MentalMath.Core.Abstractions;

public interface IMentalMathService
{
    MathProblem GetNewMathProblem();
}