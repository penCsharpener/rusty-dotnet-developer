using System.Security.Cryptography;
using MentalMath.Core.Abstractions;
using MentalMath.Core.Models.Enums;

namespace MentalMath.Core.Services;

public sealed class RandomService : IRandomService
{
    private readonly IOptionsService _optionsService;

    public RandomService(IOptionsService optionsService)
    {
        _optionsService = optionsService;
    }

    public MathOperation GetMathOperation()
    {
        return (MathOperation) RandomNumberGenerator.GetInt32(1, 5);
    }

    public int GetRandomNumber()
    {
        return RandomNumberGenerator.GetInt32(1, _optionsService.Options.HighestAvailableNumber);
    }
}