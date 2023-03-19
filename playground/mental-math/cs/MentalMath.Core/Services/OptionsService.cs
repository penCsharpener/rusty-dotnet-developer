using MentalMath.Core.Abstractions;
using MentalMath.Core.Models;

namespace MentalMath.Core.Services;

public sealed class OptionsService : IOptionsService
{
    public MentalMathOptions Options { get; } = new();
}