using MentalMath.Core.Models.Enums;

namespace MentalMath.Core.Models;

public sealed class MathProblem
{
    public int NumberOne { get; set; }
    public int NumberTwo { get; set; }
    public int Result { get; set; }
    public MathOperation? MathOperation { get; set; }
}