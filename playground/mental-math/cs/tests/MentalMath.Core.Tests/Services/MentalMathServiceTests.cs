using MentalMath.Core.Abstractions;
using MentalMath.Core.Models;
using MentalMath.Core.Models.Enums;
using MentalMath.Core.Services;

namespace MentalMath.Core.Tests.Services;

public sealed class MathProblemValidatorTests
{
    private readonly IOptionsService _optionsService;
    private readonly MathProblemValidator _testObject;

    public MathProblemValidatorTests()
    {
        _optionsService = Substitute.For<IOptionsService>();

        _optionsService.Options.Returns(new MentalMathOptions
        {
            PlayTime = TimeSpan.FromMinutes(5),
            AllowNegativeResults = false,
            HighestAvailableNumber = 101
        });

        _testObject = new(_optionsService);
    }

    [Theory]
    [InlineData(2, 0, MathOperation.Division, 0, false)]
    [InlineData(95, 32, MathOperation.Division, 0, false)]
    [InlineData(10, 5, MathOperation.Division, 2, true)]
    [InlineData(12, 12, MathOperation.Substraction, 0, true)]
    [InlineData(3, 34, MathOperation.Multiplication, 0, false)]
    [InlineData(101, 1, MathOperation.Addition, 0, false)]
    [InlineData(100, 1, MathOperation.Addition, 101, true)]
    public void GetNewMathProblem_Returns_Valid_MathProblem(int numberOne, int numberTwo, MathOperation mathOperation, int givenResult, bool expectedResult)
    {
        var mathProblem = new MathProblem
        {
            NumberOne = numberOne,
            NumberTwo = numberTwo,
            MathOperation = mathOperation
        };

        var result = _testObject.IsMathProblemValid(mathProblem);

        result.Should().Be(expectedResult);
        mathProblem.Result.Should().Be(givenResult);
    }
}