using System.Diagnostics;

namespace aoc2020;

public static class Extensions
{
    /// <summary>
    ///     increased accuracy for stopwatch based on frequency.
    ///     <see
    ///         href="http://geekswithblogs.net/BlackRabbitCoder/archive/2012/01/12/c.net-little-pitfalls-stopwatch-ticks-are-not-timespan-ticks.aspx">
    ///         blog
    ///         details here
    ///     </see>
    /// </summary>
    /// <param name="stopwatch"></param>
    /// <returns></returns>
    public static double ScaleMilliseconds(this Stopwatch stopwatch) =>
        1_000 * stopwatch.ElapsedTicks / (double)Stopwatch.Frequency;

    public static bool Contains(this Range range, int i) => i >= range.Start.Value && i <= range.End.Value;

    /// <summary>
    /// Given an array, it returns a rotated copy.
    /// </summary>
    /// <param name="array">The two dimensional jagged array to rotate.</param>
    public static T[][] Rotate<T>(this T[][] array)
    {
        var result = new T[array[0].Length][];
        for (var i = 0; i < result.Length; i++)
            result[i] = new T[array.Length];

        for (var i = 0; i < array.Length; i++)
        for (var j = 0; j < array[i].Length; j++)
            result[i][j] = array[array.Length - j - 1][i];

        return result;
    }

    /// <summary>
    /// Given a jagged array, it returns a diagonally flipped copy.
    /// </summary>
    /// <param name="array">The two dimensional jagged array to flip.</param>
    public static T[][] FlipHorizontally<T>(this IEnumerable<T[]> array) =>
        array.Select(x => x.Reverse().ToArray()).ToArray();
}
