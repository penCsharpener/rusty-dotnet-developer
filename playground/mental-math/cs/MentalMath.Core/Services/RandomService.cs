using System.Security.Cryptography;
using MentalMath.Core.Abstractions;
using MentalMath.Core.Extensions;
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
        var availableOptions = new Dictionary<int, MathOperation>();
        var options = _optionsService.Options.MathOperations.ToArray();

        for (var i = 1; i <= options.Length; i++)
        {
            availableOptions.Add(i, options[i - 1]);
        }

        return availableOptions[RandomNumberGenerator.GetInt32(1, options.Length + 1)];
    }

    public int GetRandomNumber()
    {
        return RandomNumberGenerator.GetInt32(1, _optionsService.Options.HighestAvailableNumber);
    }

    public int GetRandomNumberSquared()
    {
        return RandomNumberGenerator.GetInt32(1, (int) Math.Sqrt(_optionsService.Options.HighestAvailableNumber));
    }
}