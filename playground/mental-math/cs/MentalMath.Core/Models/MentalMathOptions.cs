using MentalMath.Core.Models.Enums;

namespace MentalMath.Core.Models;

public sealed class MentalMathOptions
{
    public bool AllowNegativeResults { get; set; }
    public int HighestAvailableNumber { get; set; }
    public TimeSpan PlayTime { get; set; }
    public MathOperation MathOperations { get; set; }
}