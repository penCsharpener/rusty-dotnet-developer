using MentalMath.Core.Models.Enums;

namespace MentalMath.Core.Abstractions;

public interface IRandomService
{
    MathOperation GetMathOperation();
    int GetRandomNumber();
    int GetRandomNumberSquared();
}