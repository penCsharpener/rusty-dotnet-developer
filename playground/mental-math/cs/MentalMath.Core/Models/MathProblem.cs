using MentalMath.Core.Models.Enums;

namespace MentalMath.Core.Models;

public sealed class MathProblem
{
    public int NumberOne { get; set; }
    public int NumberTwo { get; set; }
    public int Result { get; set; }
    public MathOperation? MathOperation { get; set; }
    public char MathOperationSymbol => GetOperator();

    public override string ToString()
    {
        return $"{NumberOne} {MathOperation} {NumberTwo} = {Result}";
    }

    private char GetOperator()
    {
        return MathOperation switch
        {
            Enums.MathOperation.Addition => '+',
            Enums.MathOperation.Division => '/',
            Enums.MathOperation.Multiplication => '*',
            Enums.MathOperation.Substraction => '-',
            _ => ' '
        };
    }
}