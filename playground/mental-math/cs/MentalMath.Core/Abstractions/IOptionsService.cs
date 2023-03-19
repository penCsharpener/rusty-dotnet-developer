using MentalMath.Core.Models;

namespace MentalMath.Core.Abstractions;

public interface IOptionsService
{
    public MentalMathOptions Options { get; }
}