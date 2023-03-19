using MentalMath.Console.Services;
using MentalMath.Core.Abstractions;
using MentalMath.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MentalMath.Console;

public class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddScoped<IMentalMathService, MentalMathService>()
            .AddScoped<IMathProblemValidator, MathProblemValidator>()
            .AddScoped<IRandomService, RandomService>()
            .AddScoped<IOptionsService, OptionsService>()
            .AddScoped<ConsoleCompositionRoot>();

        var provider = services.BuildServiceProvider();
        var app = provider.GetRequiredService<ConsoleCompositionRoot>();

        app.GreetUser();
        app.GetOptions();
        app.Play();
    }
}