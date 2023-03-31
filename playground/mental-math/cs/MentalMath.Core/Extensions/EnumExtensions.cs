namespace MentalMath.Core.Extensions;

public static class EnumExtensions
{
    public static T[] ToArray<T>(this T value) where T : struct, Enum
    {
        if (!typeof(T).IsDefined(typeof(FlagsAttribute), false))
        {
            return new[] { value };
        }

        return Enum.GetValues<T>().Where(e => value.HasFlag(e)).ToArray();
    }
}